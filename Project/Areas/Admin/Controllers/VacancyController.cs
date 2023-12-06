using AutoMapper;
using Humanizer;
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
            IEnumerable<VacancyDto> vacancies = (await _unitOfWork.Vacancy.GetAll("AppUser,Position,StatusVacancy,Department")).Select(v => _mapper.Map<VacancyDto>(v)).ToList();
            return View(vacancies);
        }
        public async Task<IActionResult> Upsert(string? id)
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
            if (id == null)
            {
                //create
                return View(vm);
            }
            else
            {
                //update
                vm.StatusList = (await _unitOfWork.StatusVacancy.GetAll()).Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                });
                vm.vacancyDto = _mapper.Map<VacancyDto>(await _unitOfWork.Vacancy.Get(v => v.Vacancy_Id == id));
                if (user.Id == vm.vacancyDto!.Hr_Id)
                {
                    return View(vm);
                }
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<  IActionResult> Upsert(VacancyVM vm, string[] joblist, int isupdate)
        {
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
                if (isupdate != 0)
                {
                    if (user.Id != vm.vacancyDto!.Hr_Id)
                    {
                        return RedirectToAction("Index");
                    }
                    _unitOfWork.Vacancy.Update(_mapper.Map<Vacancy>(vm.vacancyDto));
                    TempData["AlertMessageVacancy"] = "Update Vacancy Successfully";

                }
                else
                {
                    Vacancy v = await _unitOfWork.Vacancy.Get(v => v.Vacancy_Id == vm.vacancyDto!.Vacancy_Id);
                    if (v != null)
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
                    TempData["AlertMessageVacancy"] = "Create Vacancy Successfully";
                }
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(vm);
        }
        public async Task<IActionResult> Detail(string id)
        {
            List<ApplicantVacancyDto> avs = (await _unitOfWork.ApplicantVacancy.GetAll("Applicant,StatusApplicant")).Where(av => av.Vacancy_Id == id && av.StatusApplicant_Id == 1).Select(av => _mapper.Map<ApplicantVacancyDto>(av)).ToList();
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
        public async Task<IActionResult> ChangeStatus(int idOfApplicantVacancy, string idOfVacancy)
        {
            var user = await _userManager.GetUserAsync(User);
            ApplicantVacancy a = await _unitOfWork.ApplicantVacancy.Get(a => a.Id == idOfApplicantVacancy);
            a.StatusApplicant_Id = 4;
            a.Hr_Id = user.Id;
            _unitOfWork.ApplicantVacancy.Update(a);
            await _unitOfWork.Save();
            return RedirectToAction("Detail", new { id = idOfVacancy });
        }
        [HttpPost]
        public async Task<IActionResult> Download(int id)
        {
            ApplicantVacancyDto av = _mapper.Map<ApplicantVacancyDto>(await _unitOfWork.ApplicantVacancy.Get(av => av.Id == id));
            byte[] byteArr = av.Attachment!;
            string? mimeType = "application/pdf";
            return new FileContentResult(byteArr, mimeType)
            {
                FileDownloadName = $"{av.Vacancy_Id}.pdf",
            };
        }
        public async Task<IActionResult> AsignInterview(int idOfApplicantVacancy,string idOfVacancy)
        {
            var user = await _userManager.GetUserAsync(User);
            List<AppUser> interviews = (List<AppUser>)await _userManager.GetUsersInRoleAsync(SD.Role_Interview);
            InterviewVM vm = new InterviewVM()
            {
                IdOfVacancy = idOfVacancy,
                IdOfApplicanVacancy = idOfApplicantVacancy,
                InterviewVacancy = new InterviewVacancyDto(),
                InterviewList = interviews.Where(u => u.Department_Id == user.Department_Id).Select(u => new SelectListItem
                {
                    Text = u.Fullname + $" ({u.Employeecode})",
                    Value = u.Id
                })
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AsignInterview(InterviewVM vm)
        {
            var user = await _userManager.GetUserAsync(User);
            //thay đổi trạng thái của applicanvacancy
            ApplicantVacancy a = await _unitOfWork.ApplicantVacancy.Get(a => a.Id == vm.IdOfApplicanVacancy);
            a.StatusApplicant_Id = 2;
            a.Hr_Id = user.Id;
            //thêm dữ liệu vào bảng interviewvacancy
            if (vm.InterviewVacancy!.StartDate != null)
            {
                vm.InterviewVacancy!.StatusInterview_Id = 2;
            }
            vm.InterviewVacancy!.StatusInterview_Id = 1;
            vm.InterviewVacancy!.ApplicantVacancy_Id = vm.IdOfApplicanVacancy;
            _unitOfWork.InterviewVacancy.Create(_mapper.Map<InterviewVacancy>(vm.InterviewVacancy));
            await _unitOfWork.Save();
            return RedirectToAction("Detail", new { id = vm.IdOfVacancy });
        }
    }

}