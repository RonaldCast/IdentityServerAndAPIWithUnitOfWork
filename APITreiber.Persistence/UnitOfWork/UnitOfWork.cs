using System.Threading.Tasks;
using APITreiber.DomainModel;
using APITreiber.Persistence.Repository;
using APITreiber.Persistence.Repository.Contracts;
using APITreiber.Persistence.UnitOfWork.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace APITreiber.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IDbContextTransaction _dbTransaction;

        private PersonRepository _personRepository;
        
        public UnitOfWork(AppDbContext dbContext)
        {
         
            _dbContext = dbContext;
        }

        public IPersonRepository Persons => _personRepository ??= new PersonRepository(_dbContext);
        
        public void Commit()
        {
            _dbTransaction.Commit();
        }

        public void CreateTransaction()
        {
            _dbTransaction = _dbContext.Database.BeginTransaction();
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void DisposeAsync()
        {
            _dbContext.DisposeAsync();
        }

        public async Task CommitAsync()
        {
            await _dbTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbTransaction.RollbackAsync();
        }
    }
}