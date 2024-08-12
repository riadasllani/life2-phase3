using MatchingApp.Data.Repository;
namespace MatchingApp.Data
{
    public interface IUnitOfWork 
    {
        public IMatchingAppRepository<TEntity> Repository<TEntity>() where TEntity : class;
        bool Complete();
    }
}
