using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Services.IRepository;
using Project.SessionExtend;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Project.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        IUnitOfWork _unitOfWork;
        IHttpContextAccessor _contextAccessor;
        IMapper _mapper;
        IWebHostEnvironment _env;
        private readonly IEmailSender _emailSender;


        public HomeController(IUnitOfWork unitOfWork , IHttpContextAccessor contextAccessor, IMapper mapper , IWebHostEnvironment env , IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _env = env;
            _emailSender = emailSender;
            _unitOfWork.Vacancy.Check();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public async Task<IActionResult> Vacancies(int page = 0 , string? skill = null , string? Department_Id = null , string? Place = null , int? Position_Id = null)
        {
            ViewData["ListFiled"] = (await _unitOfWork.Department.GetAll()).Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Department_Id
            });
            var places = await _unitOfWork.Vacancy.GetAll();

            var uniqueProvinces = places.Select(v => v.Place.Split(',').Last().Trim()).Distinct();

            ViewData["ListCountry"] = uniqueProvinces.Select(province => new SelectListItem
            {
                Text = province,
                Value = province
            });
            ViewData["ListPosition"] = (await _unitOfWork.Position.GetAll()).Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });

            int PageSize = 5;
            var x = (await _unitOfWork.Vacancy.GetAll_Vacancies()).Where(v => v.StatusVacancy_Id == 1).Reverse();
            int count = x.Count();
            ViewData["countall"] = count;
            List<Vacancy> vacancies = x.Skip(page * PageSize).Take(PageSize).ToList();

            if (skill != null || Department_Id != null || Place != null || Position_Id != null)
            {
                ViewBag.Skill = skill;
                ViewBag.Department_Id = Department_Id;
                ViewBag.Place = Place;
                ViewBag.Position_Id = Position_Id;

                x = x.Where(v =>
                    (Department_Id == null || v.Department_Id == Department_Id) &&
                    (Place == null || v.Place!.Contains(Place)) &&
                    (Position_Id == null || v.Position_Id == Position_Id));
                if (skill != null)
                {
                    List<VacancySkill> vs = (await _unitOfWork.VacancySkill.GetAll("Skill")).Where(vs => vs.Skill!.Name!.ToLower() == skill!.ToLower()).ToList();
                    List<string> idList = vs.Select(v => v.Vacancy_Id!).ToList();
                    x = x.Where(v => (skill == null || idList.Contains(v.Vacancy_Id!)));
                }
                count = x.Count();
                ViewData["countsearch"] = count;
                vacancies = x.Skip(page * PageSize).Take(PageSize).ToList();
            }
            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);
            ViewBag.Page = page;
            return View(vacancies);
        }
        public async Task<IActionResult> Detail_Vacancy(string id)
        {
            Vacancy? vacancy = await _unitOfWork.Vacancy.Vacancy_Detail(id);
            return View(vacancy);
        }
        [HttpPost]
        public async Task<IActionResult> SubmitCV(IFormFile file , string vacancyid)
        {
            var userSession = _contextAccessor.HttpContext!.Session.GetObjectFromJson<UserSession>("userSession");
            if (userSession != null)
            {
                if (file != null)
                {
                    ApplicantVacancy? a = await _unitOfWork.ApplicantVacancy.CheckExistApplicantVacancy(userSession.Id , vacancyid);
                    if (a != null)
                    {
                        TempData["AlertMessageError"] = "You have submitted your CV for this position";
                        return RedirectToAction("Detail_Vacancy", new { id = vacancyid });
                    }
                    ApplicantVacancy applicantVacancy = new ApplicantVacancy()
                    {
                        Vacancy_Id = vacancyid,
                        StatusApplicant_Id = 1,
                        Applicant_Id = userSession.Id
                    };
                    if (file.Length > 0 && file.Length < 30000000)
                    {
                        using (var target = new MemoryStream())
                        {
                            file.CopyTo(target);
                            applicantVacancy.Attachment = target.ToArray();
                            Console.WriteLine(applicantVacancy.Attachment);
                        }
                    }
                    _unitOfWork.ApplicantVacancy.Create(applicantVacancy);
                    await _unitOfWork.Save();
                    TempData["AlertMessageSuccess"] = "Apply CV Successfully";
                    return RedirectToAction("Detail_Vacancy" , new {id = vacancyid});
                }
            }
            return RedirectToAction("Login");

        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM vm)
        {
            Applicant? applicant = _unitOfWork.Applicant.VerifyPassword(vm.Email!, vm.Password!);
            if (applicant != null)
            {
                var userSession = new UserSession();
                userSession.Id = applicant.Id;
                userSession.UserName = applicant.Fullname;
                userSession.Email = applicant.Email;
                userSession.Phone = applicant.Phone;

                _contextAccessor.HttpContext!.Session.SetObjectAsJson("userSession", userSession);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["LoginErrorAlertMessage"] = "Email Or Password Is Incorrect";
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(ApplicantDto dto)
        {

            if (ModelState.IsValid)
            {
                if (await _unitOfWork.Applicant.CheckAccountExist(dto.Email!))
                {
                    TempData["RegisterErrorAlertMessage"] = "Email Already Exists";
                    return View(dto);
                }
                dto.Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png";
                dto.Password = _unitOfWork.Applicant.HashPassword(dto.Password!);    
                _unitOfWork.Applicant.Create(_mapper.Map<Applicant>(dto));
                await _unitOfWork.Save();
                TempData["LoginSuccessAlertMessage"] = "Creating Account Successfully";
                return RedirectToAction("Login");
            }
            else
            {
                return View(dto);
            }
        }
        public async Task<IActionResult> Profile()
        {
            var userSession = _contextAccessor.HttpContext!.Session.GetObjectFromJson<UserSession>("userSession");
            if (userSession != null)
            {
                int idUser = userSession.Id;
                ApplicantDto applicant = _mapper.Map<ApplicantDto>(await _unitOfWork.Applicant.Get(a => a.Id == idUser));
                return View(applicant);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Profile(ApplicantDto dto , IFormFile? file)
        {
           
            string wwwRootPath = _env.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string applicantPath = Path.Combine(wwwRootPath, @"assets\client\img\img-applicant");
                if (dto.Image != "assets\\client\\img\\img-applicant\\default-image-applicant.png")
                {
                    if (!string.IsNullOrEmpty(dto.Image))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, dto.Image.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(applicantPath, fileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                dto.Image = @"assets\client\img\img-applicant\" + fileName;
            }
            _unitOfWork.Applicant.Update(_mapper.Map<Applicant>(dto));
            await _unitOfWork.Save();
           
            TempData["ProfileSuccessAlertMessage"] = "Saved Successfully";
            return RedirectToAction("Profile");
        }
        public async Task<IActionResult> ChangePassword(string email , string oldpassword , string newpassword , string confirmpassword)
        {
            Applicant a = await _unitOfWork.Applicant.Get(a => a.Email == email);
            if (a.Password != _unitOfWork.Applicant.HashPassword(oldpassword))
            {
                TempData["ProfileErrorAlertMessage"] = "Old Password Is Not Correct";
                return RedirectToAction("Profile");
            }
            if(newpassword == confirmpassword) {
                var regex = @"^(?=.*\d)(?=.*[\W_])[^\s*]{7,}$";
                var match = Regex.Match(confirmpassword, regex, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    a.Password = _unitOfWork.Applicant.HashPassword(confirmpassword);
                    _unitOfWork.Applicant.Update(a);
                    await _unitOfWork.Save();
                    TempData["ProfileSuccessAlertMessage"] = "Changed Password Successfully";
                    return RedirectToAction("Profile");
                }
                TempData["ProfileErrorAlertMessage"] = "New Password has at least 7 characters, 1 number and 1 special character";
                return RedirectToAction("Profile");
            }
            TempData["ProfileErrorAlertMessage"] = "New Password And Confirm Password Not Math";
            return RedirectToAction("Profile");
        }
        public async Task<IActionResult> ForgotPassword(string? email)
        {
            Applicant a = await _unitOfWork.Applicant.Get(a => a.Email == email);
            if (a != null)
            {
                var r = new Random();
                string randompass = new string(Enumerable.Range(0, 10)
                .Select(n =>
                {
                    int randomNumber = r.Next(0, 36);
                    char character = (char)(randomNumber < 10 ? randomNumber + '0' : randomNumber - 10 + 'A');
                    return character;
                })
                .ToArray());
                await _emailSender.SendEmailAsync(
                    email,
                    "Recover Password",
                    $"Your New Password Is : {randompass}");

                a.Password = _unitOfWork.Applicant.HashPassword(randompass);
                _unitOfWork.Applicant.Update(a);
                await _unitOfWork.Save();   
                TempData["LoginSuccessAlertMessage"] = "Please Check Email";
                return RedirectToAction("Login");
            }
            TempData["LoginErrorAlertMessage"] = "Email Not Exist";
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            _contextAccessor.HttpContext!.Session.Remove("userSession");
            return RedirectToAction("Index");
        }

    }
}
