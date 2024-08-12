using System.Linq.Expressions;

namespace MatchingApp.Data.Repository
{
    public class MatchingAppRepository<TEntity> : IMatchingAppRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;
        public MatchingAppRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            var result = _dbContext.Set<TEntity>();
            return result;
        }

        public IQueryable<TEntity> GetById(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }
        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression);
        }

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void CreateRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}
