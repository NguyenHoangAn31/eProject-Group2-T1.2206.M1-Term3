using Project.Data;
using Project.Services.IRepository;

namespace Project.Services
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
