using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Services.IRepository;
using System.Data;
using System.Text.Encodings.Web;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Interview)]
    public class InterviewVacancyController : Controller
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        private UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;
        public InterviewVacancyController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager , IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public async Task<IActionResult> Index()
        {
            List<InterviewVacancy> interviewVacancies = (await _unitOfWork.InterviewVacancy.GetAllInterview()).Select(iv => iv).ToList();  
            return View(interviewVacancies);
        }
        public async Task<IActionResult> Detail(int id)
        {
            InterviewVacancy? iv = await _unitOfWork.InterviewVacancy.GetDetail(id);
            return View(iv);
        }
        public async Task<IActionResult> ChangeStatus(int id, int IdStatus)
        {
            InterviewVacancy? iv = await _unitOfWork.InterviewVacancy.GetDetail(id);
            iv!.StatusInterview_Id = IdStatus;
            iv.EndDate = DateTime.Now;
            iv.ApplicantVacancy!.StatusApplicant_Id = IdStatus;
            _unitOfWork.InterviewVacancy.Update(iv);
            await _unitOfWork.Save();
            if (IdStatus ==3) {
                //send mail hired
                iv.ApplicantVacancy.Vacancy!.ActualQuantity += 1;
                await _unitOfWork.Save();
                await _emailSender.SendEmailAsync(
                    iv.ApplicantVacancy.Applicant!.Email,
                    "Interview Result",
                    $"Subject: Congratulations! Successful interview<br>Dear {iv.ApplicantVacancy.Applicant.Fullname},<br>Hello {iv.ApplicantVacancy.Applicant.Fullname},<br>I hope this email finds you in a good and cheerful mood. I am very pleased to announce that your interview was successful. This is an important step and I believe you have left a positive impression on our team.<br>Your professionalism and knowledge were appreciated during the interview process, and we look forward to the opportunity to work with you at StartUp. Your commitment and abilities will certainly be a valuable contribution to our organization.<br>We will contact you as soon as possible to notify you of the final results of the recruitment process. In the meantime, keep the faith and be ready for the next steps.<br>If you have any questions or need any further information, don't hesitate to contact me. I am always happy to assist you.<br>Congratulations again and thank you for taking the time to participate in the interview process with us.<br>Best regards,<br>Interviewer : {iv.AppUser!.Fullname}<br>Vacancy : {iv.ApplicantVacancy!.Vacancy!.Title}<br>Company Name : StartUp<br>Phone : 012345678<br>Email : jobnavigator999@gmail.com");
            }
            else
            {
                //sebd mail baned
                await _emailSender.SendEmailAsync(
                    iv.ApplicantVacancy.Applicant!.Email,
                    "Interview Result",
                    $"Subject: Information about Interview Results<br>Dear {iv.ApplicantVacancy.Applicant.Fullname},<br>Hello {iv.ApplicantVacancy.Applicant.Fullname},<br>I hope you are well and in a good mood. I would like to share information about the results of the interview process you participated in at StartUp.<br>First, I want to thank you for taking the time and effort to participate in this interview with us. This process always values the commitment and knowledge of each candidate, and we regret to announce that we have selected another candidate who is a better fit for the position.<br>This was not an easy decision and we appreciate everything you brought to the interview process. Your knowledge and skills are impressive, and we hope you will continue to maintain your passion and drive in your career.<br>We sincerely thank you for your interest and for your challenging time with us. If you want specific feedback or have any questions, don't hesitate to contact us.<br>Wishing you success in your future opportunities and sincerely hope you find growth in your career.<br>Best regards,<br>interviewer : {iv.AppUser!.Fullname}<br>Vacancy : {iv.ApplicantVacancy!.Vacancy!.Title}<br>Company Name : StartUp<br>Phone : 012345678<br>Email : jobnavigator999@gmail.com");
            }
            return RedirectToAction("Detail", new { id = id });
        }
        public async Task<IActionResult> SetDate(int id , string email , DateTime startdate , int? checkstatus)
        {
            InterviewVacancy? iv = await _unitOfWork.InterviewVacancy.GetDetail(id);
            iv!.StartDate = startdate;
            if (checkstatus == 0)
            {
                iv!.StatusInterview_Id = 2;
            }
            await _unitOfWork.Save();
            await _emailSender.SendEmailAsync(
                    email,
                    "Date Interview",
                    $"Subject: Confirm Interview Appointment<br>Dear {iv.ApplicantVacancy!.Applicant!.Fullname},<br>Hello {iv.ApplicantVacancy.Applicant.Fullname},<br>I hope you are having a good day. I am pleased to announce that we would like to confirm an interview appointment with you for the position at StartUp.<br>Details of the appointment are as follows:<br>Time: {startdate}<br>Location: {iv.ApplicantVacancy!.Vacancy!.Place}<br>Interviewer: {iv.AppUser!.Fullname} (if specific information is available)<br>We hope you will be able to arrive on time and be ready to participate in the interview. If there are any changes that need to be accommodated, or you cannot attend at the confirmed time, please let us know in advance.<br>If you need additional information or support before your interview, don't hesitate to contact us directly.<br>We hope that this appointment will provide an opportunity for us to learn more about each other and about the job position we propose.<br>Thank you very much and we hope to see you soon at your next appointment.<br>Best regards,<br>Interviewer : {iv.AppUser!.Fullname}<br>Vacancy : {iv.ApplicantVacancy!.Vacancy!.Title}<br>Company Name : StartUp<br>Phone : 012345678<br>Email : jobnavigator999@gmail.com");
            return RedirectToAction("Detail" , new { id  = id});
        }
    }
}
