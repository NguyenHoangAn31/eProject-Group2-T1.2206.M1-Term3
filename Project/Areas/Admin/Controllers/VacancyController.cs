using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(Roles = SD.Role_Hr)]
    public class VacancyController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        private UserManager<AppUser> _userManager;

        public VacancyController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<VacancyDto> vacancies = (await _unitOfWork.Vacancy.GetAll("AppUser,Position,StatusVacancy,Department")).Select(v=>_mapper.Map<VacancyDto>(v)).ToList();
            return View(vacancies);
        }
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            VacancyVM vm = new()
            {
                vacancyDto = new VacancyDto(),
                PositionList = (await _unitOfWork.Position.GetAll()).Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                }),
                JobList = (await _unitOfWork.Job.GetAll()).Where(j => j.Department_Id == user.Department_Id).Select(j => new SelectListItem
                {
                    Text = j.Name,
                    Value = j.Id.ToString()
                })
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(VacancyVM vm , string[] joblist) {
            var user = await _userManager.GetUserAsync(User);
            vm.PositionList = (await _unitOfWork.Position.GetAll()).Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });
            vm.JobList = (await _unitOfWork.Job.GetAll()).Where(j => j.Department_Id == user.Department_Id).Select(j => new SelectListItem
            {
                Text = j.Name,
                Value = j.Id.ToString()
            });
            if (ModelState.IsValid)
            {
                Vacancy v = await _unitOfWork.Vacancy.Get(v => v.Vacancy_Id == vm.vacancyDto!.Vacancy_Id);
                if (v!=null)
                {
                    TempData["AlertMessageVacancy"] = "The Vacancy Id Already Exist";
                    return View(vm);
                }
                vm.vacancyDto!.Department_Id = user.Department_Id;
                vm.vacancyDto.Hr_Id = user.Id;
                vm.vacancyDto!.StatusVacancy_Id = 1;
                _unitOfWork.Vacancy.Create(_mapper.Map<Vacancy>(vm.vacancyDto));
                foreach (var job in joblist)
                {
                    VacancyJob vj = new VacancyJob()
                    {
                        Vacancy_Id = vm.vacancyDto!.Vacancy_Id,
                        Job_Id = int.Parse(job)
                    };
                    _unitOfWork.VacancyJob.Create(vj);
                }
                await _unitOfWork.Save();
                TempData["AlertMessageVacancy"] = "Create Vacancy Successfully";
                return RedirectToAction("Index");
            }
            
            return View(vm);
        }
        public async Task<IActionResult> Detail(string id)
        {
            List<ApplicantVacancyDto> avs = (await _unitOfWork.ApplicantVacancy.GetAll("Applicant,StatusApplicant")).Where(av => av.Vacancy_Id == id).Select(av => _mapper.Map<ApplicantVacancyDto>(av)).ToList();
            Vacancy? v = await _unitOfWork.Vacancy.Vacancy_Detail(id);
            ViewData["Vacancy"] = v;
            var user = await _userManager.GetUserAsync(User);
            if (user.Id == v!.Hr_Id)
            {
                return View(avs);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Download(int id)
        {
            ApplicantVacancyDto av = _mapper.Map<ApplicantVacancyDto>(await _unitOfWork.ApplicantVacancy.Get(av => av.Id == id));
            byte[] byteArr = av.Attachment!;
            string? mimeType = "application/pdf";
            return new FileContentResult(byteArr,mimeType) {    
                FileDownloadName = $"{av.Vacancy_Id}.pdf",
            };
        }
    }
}
