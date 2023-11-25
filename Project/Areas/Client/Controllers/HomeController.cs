using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Services.IRepository;

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
        public IActionResult Vacancies()
        {
            return View();
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
        public async Task<IActionResult> Login(LoginVM vm)
        {
            int? id = (await _unitOfWork.Applicant.CheckLogin(vm.Email!, vm.Password!));
            if ( id != null && id != 0)
            {
                _contextAccessor.HttpContext!.Session.SetInt32("idUser", id.Value); 
                return RedirectToAction("Profile");
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
                    TempData["AlertMessageError"] = "Account Already Exists";
                    return View(dto);
                }
                dto.Image = "assets\\client\\img\\img-applicant\\default-image-applicant.png";
                _unitOfWork.Applicant.Create(_mapper.Map<Applicant>(dto));
                await _unitOfWork.Save();
                TempData["AlertMessageSuccess"] = "Creating Account Successfully";
                return View();
            }
            else
            {
                return View(dto);
            }
        }
        public async Task<IActionResult> Profile()
        {
            if (_contextAccessor.HttpContext!.Session.GetInt32("idUser") != null)
            {
                int idUser = _contextAccessor.HttpContext.Session.GetInt32("idUser") ?? default(int);
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

                    using (var fileStream = new FileStream(Path.Combine(applicantPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    dto.Image = @"assets\client\img\img-applicant\" + fileName;
                }



                _unitOfWork.Applicant.Update(_mapper.Map<Applicant>(dto));
                await _unitOfWork.Save();
            }
            TempData["AlertMessage"] = "Saved Successfully";
            return RedirectToAction("Profile");
        }
        public IActionResult Logout()
        {
            _contextAccessor.HttpContext!.Session.Remove("idUser");
            return RedirectToAction("Index");
        }

    }
}
