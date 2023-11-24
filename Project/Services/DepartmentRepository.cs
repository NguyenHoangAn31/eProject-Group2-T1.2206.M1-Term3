using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
