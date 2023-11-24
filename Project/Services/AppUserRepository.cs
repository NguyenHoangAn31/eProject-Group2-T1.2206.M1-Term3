using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
