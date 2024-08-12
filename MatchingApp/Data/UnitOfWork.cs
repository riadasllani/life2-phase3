using MatchingApp.Data.Repository;
using System.Collections;

namespace MatchingApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private Hashtable _repositories;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool Complete()
        {
            var numberOfAffectedRows = _dbContext.SaveChanges();
            return numberOfAffectedRows > 0;
        }

        public IMatchingAppRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(MatchingAppRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);
                _repositories.Add(type, repositoryInstance);
            }
            return (IMatchingAppRepository<TEntity>)_repositories[type];
        }
         
}
}
