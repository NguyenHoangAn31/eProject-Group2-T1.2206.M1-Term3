using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using PagedList;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Services.IRepository;
using Project.SessionExtend;
using System.Collections;
using System.Collections.Generic;

namespace Project.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        IUnitOfWork _unitOfWork;
        IHttpContextAccessor _contextAccessor;
        IMapper _mapper;
        IWebHostEnvironment _env;

        public HomeController(IUnitOfWork unitOfWork , IHttpContextAccessor contextAccessor, IMapper mapper , IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _env = env;
            _unitOfWork.Vacancy.CheckQuantity();
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
        public async Task<IActionResult> Vacancies(int? page)
        {
          
            List<Vacancy> vacancies = (await _unitOfWork.Vacancy.GetAll_Vacancies()).Where(v=>v.StatusVacancy_Id == 1).ToList();
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
                TempData["AlertMessage"] = "Email Or Password Is Incorrect";
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
                    TempData["AlertMessageError"] = "Email Already Exists";
                    return View(dto);
                }
                dto.Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png";
                dto.Password = _unitOfWork.Applicant.HashPassword(dto.Password!);    
                _unitOfWork.Applicant.Create(_mapper.Map<Applicant>(dto));
                await _unitOfWork.Save();
                TempData["AlertMessageSuccess"] = "Creating Account Successfully";
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
        public async Task<IActionResult> Profile(ApplicantDto dto , IFormFile file)
        {
            if (ModelState.IsValid)
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
            }
            _unitOfWork.Applicant.Update(_mapper.Map<Applicant>(dto));
            await _unitOfWork.Save();
           
            TempData["AlertMessage"] = "Saved Successfully";
            return RedirectToAction("Profile");
        }
        public IActionResult Logout()
        {
            _contextAccessor.HttpContext!.Session.Remove("userSession");
            return RedirectToAction("Index");
        }

    }
}
