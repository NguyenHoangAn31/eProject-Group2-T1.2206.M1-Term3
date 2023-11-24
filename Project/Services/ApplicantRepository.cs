using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
