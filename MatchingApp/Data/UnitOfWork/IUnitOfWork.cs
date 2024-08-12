using MatchingApp.Data.Repository;

namespace MatchingApp.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IMatchingRepository<TEntity> Repository<TEntity>() where TEntity : class;

        bool Complete();
    }
}
