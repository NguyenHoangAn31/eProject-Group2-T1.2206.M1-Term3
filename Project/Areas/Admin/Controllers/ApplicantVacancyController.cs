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
    [Authorize(Roles = SD.Role_Hr)]
    public class ApplicantVacancyController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ApplicantVacancyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ApplicantVacancyDto> result = (await _unitOfWork.ApplicantVacancy.GetAll("Applicant,Vacancy,StatusApplicant")).Select(c => _mapper.Map<ApplicantVacancyDto>(c)).ToList();
            return View(result.Reverse());
        }
        public async Task<IActionResult> Detail(int id)
        {
            ApplicantVacancyDto? av = _mapper.Map<ApplicantVacancyDto>(await _unitOfWork.ApplicantVacancy.GetDetail(id));
            return View(av);
        }
    }
}
