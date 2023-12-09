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
                .ToListAsync();
            return ivs;
        }

        public async Task<InterviewVacancy?> GetDetail(int IdInterview)
        {
            InterviewVacancy? iv = await _db.InterviewsVacancies!
                .Include(iv => iv.AppUser)
                .Include(iv => iv.ApplicantVacancy)
                .ThenInclude(iv => iv!.Applicant)
                .Include(iv => iv.ApplicantVacancy)
                .ThenInclude(iv => iv!.AppUser)
                .Include(iv => iv.ApplicantVacancy)
                .ThenInclude(iv => iv!.Vacancy)
                .ThenInclude(iv => iv!.VacanciesSkills!)
                .ThenInclude(x => x.Skill)
                .Include(iv => iv.ApplicantVacancy)
                .ThenInclude(iv => iv!.StatusApplicant)
                .SingleOrDefaultAsync(iv => iv.Id == IdInterview);
            if (iv != null)
            {
                return iv;
            }
            return null;
        }
    }
}
