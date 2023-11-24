using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Services.IRepository;

namespace Project.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        IUnitOfWork _unitOfWork;
        IHttpContextAccessor _contextAccessor;

        public HomeController(IUnitOfWork unitOfWork , IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
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
        public async Task<IActionResult> Login(string email , string password)
        {
            int? id = (await _unitOfWork.Applicant.CheckLogin(email, password));
            if ( id != null && id != 0)
            {
                _contextAccessor.HttpContext!.Session.SetInt32("idUser", id.Value); 
                return RedirectToAction("Profile");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        
    }
}
