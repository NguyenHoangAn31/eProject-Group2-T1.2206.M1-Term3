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
    public class SkillController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public SkillController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<SkillDto> result = (await _unitOfWork.Skill.GetAll("Department")).Select(s => _mapper.Map<SkillDto>(s)).ToList();
            return View(result);
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            SkillVM vm = new()
            {
                skill = new SkillDto(),
                DepartmentList = (await _unitOfWork.Department.GetAll()).Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.Department_Id
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
                vm.skill = _mapper.Map<SkillDto>(await _unitOfWork.Skill.Get(s => s.Id == id));
                return View(vm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(SkillVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.skill!.Id != 0)
                {
                    _unitOfWork.Skill.Update(_mapper.Map<Skill>(vm.skill));
                    TempData["AlertMessageSkill"] = "Update Skill Successfully";
                }
                else
                {
                    _unitOfWork.Skill.Create(_mapper.Map<Skill>(vm.skill));
                    TempData["AlertMessageSkill"] = "Create Skill Successfully";

                }
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            vm.DepartmentList = (await _unitOfWork.Department.GetAll()).Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Department_Id
            });
            return View(vm);
            
        }

        public async Task<IActionResult> Delete(int? id)
        {
            SkillDto dto = _mapper.Map<SkillDto>(await _unitOfWork.Skill.Get(s => s.Id == id));
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(SkillDto dto)
        {
            _unitOfWork.Skill.Delete(_mapper.Map<Skill>(dto));
            await _unitOfWork.Save();
            TempData["AlertMessageSkill"] = "Delete Skill Successfully";
            return RedirectToAction("Index");
        }

    }
}
