using System;
using System.Threading.Tasks;
using APITreiber.Persistence.Repository.Contracts;

namespace APITreiber.Persistence.UnitOfWork.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        
        IPersonRepository Persons { get; }
        
        void CreateTransaction();
        void Commit();
        void Rollback();
        int Save();
        Task<int> SaveAsync();
        Task CommitAsync();
        Task RollbackAsync();

    }
}