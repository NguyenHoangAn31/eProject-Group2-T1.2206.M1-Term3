using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class VacancyRepository : Repository<Vacancy>, IVacancyRepository
    {
        public VacancyRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
