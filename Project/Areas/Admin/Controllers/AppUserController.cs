using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Services.IRepository;
using System.Data;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AppUserController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public AppUserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<AppUser> result = (await _unitOfWork.AppUser.GetAll("Department")).ToList();
            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
