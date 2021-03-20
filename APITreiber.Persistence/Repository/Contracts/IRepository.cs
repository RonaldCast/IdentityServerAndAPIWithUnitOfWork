using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITreiber.Persistence.Repository.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity> GetByIdAsync(int id);
    }
}