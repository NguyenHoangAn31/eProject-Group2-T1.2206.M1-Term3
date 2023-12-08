using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class SkillRepository : Repository<Skill>, ISkillRepository
    {
        public SkillRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
