using MatchingApp.IRepository;

namespace Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<bool> CompleteAsync();
    }
}