using System.Linq.Expressions;

namespace Project.Services.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll(string? includeProperties = null);
        Task<T> Get(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Create(T entry);
        void Delete(T entry);
        void Update(T entry);
    }
}
