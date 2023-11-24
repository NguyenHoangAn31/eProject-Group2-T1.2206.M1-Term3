using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class InterviewVacancyRepository : Repository<InterviewVacancy>, IInterviewVacancyRepository
    {
        public InterviewVacancyRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
