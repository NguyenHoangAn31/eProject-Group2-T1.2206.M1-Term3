using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class StatusVacancyRepository : Repository<StatusVacancy>, IStatusVacancyRepository
    {
        public StatusVacancyRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
