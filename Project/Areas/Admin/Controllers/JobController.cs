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
    public class JobController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public JobController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<JobDto> result = (await _unitOfWork.Job.GetAll("Department")).Select(c => _mapper.Map<JobDto>(c)).ToList();
            return View(result);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            JobVM vm = new()
            {
                job = new JobDto(),
                DepartmentList = (await _unitOfWork.Department.GetAll()).Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Department_Id
                })
            };
            if (id == null || id == 0)
            {
                //create
                return View(vm);
            }
            else
            {
                //update
                vm.job = _mapper.Map<JobDto>(await _unitOfWork.Job.Get(u => u.Id == id));
                return View(vm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(JobVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.job.Id != 0)
                {
                    _unitOfWork.Job.Update(_mapper.Map<Job>(vm.job));
                    TempData["AlertMessage"] = "Update Job Successfully";
                }
                else
                {
                    _unitOfWork.Job.Create(_mapper.Map<Job>(vm.job));
                    TempData["AlertMessage"] = "Create Job Successfully";

                }
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            vm.DepartmentList = (await _unitOfWork.Department.GetAll()).Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Department_Id
            });
            return View(vm);
            
        }

        public async Task<IActionResult> Delete(int? id)
        {
            JobDto dto = _mapper.Map<JobDto>(await _unitOfWork.Job.Get(j => j.Id == id));
            TempData["AlertMessage"] = "Delete Job Successfully";
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(JobDto dto)
        {
            _unitOfWork.Job.Delete(_mapper.Map<Job>(dto));
            await _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
