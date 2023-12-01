using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        UserManager<AppUser> _userManager;

        public AppUserController(IUnitOfWork unitOfWork, IMapper mapper , UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            //IEnumerable<AppUser> result = (await _unitOfWork.AppUser.GetAll("Department")).ToList();
            //List<AppUser> usersInRole = (List<AppUser>)await _userManager.GetUsersInRoleAsync(SD.Role_Hr);

            var allUsers = await _userManager.Users.Include("Department").ToListAsync();
            List<AppUser> usersNotInRoleAdmin = new List<AppUser>();
            foreach (var user in allUsers)
            {
                bool isInRole = await _userManager.IsInRoleAsync(user, SD.Role_Hr);
                if (isInRole)
                {
                    usersNotInRoleAdmin.Add(user);
                }
            }
            return View(usersNotInRoleAdmin);
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
