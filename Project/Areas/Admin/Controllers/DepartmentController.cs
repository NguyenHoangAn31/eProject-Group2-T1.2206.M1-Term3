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
            return View(result);
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
        public async Task<IActionResult> Upsert(DepartmentDto dto , string? isupdate = null)
        {

            if (ModelState.IsValid)
            {
                if (isupdate != null)
                {
                    _unitOfWork.Department.Update(_mapper.Map<Department>(dto));
                    TempData["AlertMessageDepartment"] = "Update Department Successfully";
                }
                else
                {
                    _unitOfWork.Department.Create(_mapper.Map<Department>(dto));
                    TempData["AlertMessageDepartment"] = "Create Department Successfully";

                }
              

                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
        
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
            _unitOfWork.Department.Delete(_mapper.Map<Department>(dto));
            await _unitOfWork.Save();
            TempData["AlertMessageDepartment"] = "Delete Department Successfully";
            return RedirectToAction("Index");
        }
    }
}
