using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class ApplicantVacancyRepository : Repository<ApplicantVacancy>, IApplicantVacancyRepository
    {
        public ApplicantVacancyRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
