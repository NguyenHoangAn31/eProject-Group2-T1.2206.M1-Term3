using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
