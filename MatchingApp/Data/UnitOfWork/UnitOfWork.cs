using MatchingApp.Data.Repository;
using System.Collections;

namespace MatchingApp.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private Hashtable _repositories;
        public UnitOfWork(ApplicationDbContext db)
        {
            _dbContext = db;
        }

        public bool Complete()
        {
            var numberOfAffectedRows = _dbContext.SaveChanges();
            return numberOfAffectedRows > 0;
        }

        public IMatchingRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.Contains(type))
            {
                var repositoryType = typeof(MatchingRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

                _repositories.Add(type, repositoryInstance);
            }

            return (IMatchingRepository<TEntity>)_repositories[type];
        }
    }
}
