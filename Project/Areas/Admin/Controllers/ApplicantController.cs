using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;
using Project.Models.ViewModel;
using Project.Services.IRepository;
using Project.SessionExtend;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]  
    public class ApplicantController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        IWebHostEnvironment _env;
        IHttpContextAccessor _contextAccessor;
        public ApplicantController(IUnitOfWork unitOfWork, IMapper mapper , IWebHostEnvironment env , IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _contextAccessor = contextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ApplicantDto> result = (await _unitOfWork.Applicant.GetAll()).Select(c => _mapper.Map<ApplicantDto>(c)).ToList();
            return View(result);
        }
        public async Task<IActionResult> Upsert(int? id)
        {
            ApplicantDto dto = new ApplicantDto();
            if (id == null || id == 0)
            {
                //create
                return View(dto);
            }
            else
            {
                //update
                dto = _mapper.Map<ApplicantDto>(await _unitOfWork.Applicant.Get(u => u.Id == id));
                return View(dto);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(ApplicantDto dto , IFormFile? file)
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
                if (dto.Id != 0)
                {
                    _unitOfWork.Applicant.Update(_mapper.Map<Applicant>(dto));
                    TempData["AlertMessageApplicant"] = "Update Applicant Successfully";
                }
                else
                {
                    _unitOfWork.Applicant.Create(_mapper.Map<Applicant>(dto));
                    TempData["AlertMessageApplicant"] = "Create Applicant Successfully";

                }
                await _unitOfWork.Save();
                return RedirectToAction("Index");
            }
          
            return View(dto);

        }
        public async Task<IActionResult> Delete(int? id)
        {
            ApplicantDto dto = _mapper.Map<ApplicantDto>(await _unitOfWork.Applicant.Get(a => a.Id == id));
            return View(dto);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ApplicantDto dto)
        {
            var userSesison = _contextAccessor.HttpContext!.Session.GetObjectFromJson<UserSession>("userSession");
            if (userSesison.Id == dto.Id)
            {
                _contextAccessor.HttpContext!.Session.Remove("userSession");
            }
            var oldImagePath =
                           Path.Combine(_env.WebRootPath,
                           dto.Image!.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Applicant.Delete(_mapper.Map<Applicant>(dto));
            await _unitOfWork.Save();
            TempData["AlertMessageApplicant"] = "Delete Applicant Successfully";
            return RedirectToAction("Index");
        }
    }
}
