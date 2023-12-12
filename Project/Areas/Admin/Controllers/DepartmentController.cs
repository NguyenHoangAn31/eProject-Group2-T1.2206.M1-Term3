using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Services.IRepository;
using System.Data;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DepartmentController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<DepartmentDto> result = (await _unitOfWork.Department.GetAll()).Select(c => _mapper.Map<DepartmentDto>(c)).ToList();
            return View(result.Reverse());
        }

        public async Task<IActionResult> Upsert(string? id)
        {
            DepartmentDto dto = new DepartmentDto();
            if (id == null || id == "")
            {
                //create
                return View(dto);
            }
            else
            {
                //update
                dto = _mapper.Map<DepartmentDto>(await _unitOfWork.Department.Get(d=>d.Department_Id == id));
                return View(dto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(DepartmentDto dto , int isupdate)
        {

            if (ModelState.IsValid)
            {
                if (isupdate != 0)
                {
                    _unitOfWork.Department.Update(_mapper.Map<Department>(dto));
                    TempData["AlertMessageDepartment"] = "Update Department Successfully";
                }
                else
                {
                    Department department = await _unitOfWork.Department.Get(d => d.Department_Id == dto.Department_Id);
                    if (department != null)
                    {
                        TempData["AlertMessageDepartment"] = "The Department Id Already Exists";
                        dto.Department_Id = null;
                        return View(dto);
                    }
                    else
                    {
                        _unitOfWork.Department.Create(_mapper.Map<Department>(dto));
                        TempData["AlertMessageDepartment"] = "Create Department Successfully";
                    }
                    

                }
              

                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            dto.Department_Id = null;
            return View(dto);
        }
        public async Task<IActionResult> Delete(string? id)
        {
            DepartmentDto dto = _mapper.Map<DepartmentDto>(await _unitOfWork.Department.Get(d => d.Department_Id == id));
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentDto dto)
        {
            try
            {
                _unitOfWork.Department.Delete(_mapper.Map<Department>(dto));
                await _unitOfWork.Save();
                TempData["AlertMessageDepartment"] = "Delete Department Successfully";
                return RedirectToAction("Index");
            }
            catch(Exception e) {
                TempData["AlertMessageDepartmentError"] = "Department Is Active";
                return RedirectToAction("Delete" , new {id = dto.Department_Id});

            }

        }
    }
}
