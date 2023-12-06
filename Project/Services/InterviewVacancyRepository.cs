using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class InterviewVacancyRepository : Repository<InterviewVacancy>, IInterviewVacancyRepository
    {
        private readonly ApplicationDbContext _db;
        public InterviewVacancyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<InterviewVacancy>> GetAllInterview()
        {
            List<InterviewVacancy> ivs = await _db.InterviewsVacancies!
              .Include(iv => iv.StatusInterview)
              .Include(iv => iv.AppUser)
              .ThenInclude(iv => iv!.Department)
              .Include(iv => iv.ApplicantVacancy)
              .ThenInclude(iv => iv!.AppUser)
              .Include(iv => iv.ApplicantVacancy)
              .ThenInclude(iv => iv!.Applicant)
              
              .ToListAsync();
            return ivs;
        }

        public async Task<InterviewVacancy> GetDetail()
        {
            throw new NotImplementedException();
        }
    }
}
