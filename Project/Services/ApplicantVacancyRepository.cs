using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class ApplicantVacancyRepository : Repository<ApplicantVacancy>, IApplicantVacancyRepository
    {
        ApplicationDbContext _db;
        public ApplicantVacancyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<ApplicantVacancy?> CheckExistApplicantVacancy(int applicantid, string vacancyid)
        {
            ApplicantVacancy? a = await _db.ApplicantsVacancies!.Include("StatusApplicant").SingleOrDefaultAsync(a => a.Applicant_Id == applicantid && a.Vacancy_Id == vacancyid);
            if (a == null)
            {
                return null;
            }
            return a;
        }

        public async Task<ApplicantVacancy?> GetWithEmail(int? id)
        {
            ApplicantVacancy? av = await _db.ApplicantsVacancies!.
                Include(av => av.Applicant).
                Include(av => av.Vacancy).
                SingleOrDefaultAsync(av => av.Id == id);
            if(av != null)
            {
                return av;
            }
            return null;
        }
       
    }
}
