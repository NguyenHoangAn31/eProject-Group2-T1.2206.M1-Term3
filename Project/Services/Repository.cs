using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Services.IRepository;
using System.Linq.Expressions;

namespace Project.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            // có khóa chính khóa ngoại thì qua project YTB để tham khảo tại vị trí này
        }

        public async Task<List<T>> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();

        }

        public void Create(T entry)
        {
            dbSet.Add(entry);
        }

        public void Delete(T entry)
        {
            dbSet.Remove(entry);
        }

        public void Update(T entry)
        {
            dbSet.Update(entry);
        }
    }
}
