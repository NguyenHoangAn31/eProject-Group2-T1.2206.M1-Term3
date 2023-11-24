using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class VacancyJobRepository : Repository<VacancyJob>, IVacancyJobRepository
    {
        public VacancyJobRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
