using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class VacancySkillRepository : Repository<VacancySkill>, IVacancySkillRepository
    {
        public VacancySkillRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
