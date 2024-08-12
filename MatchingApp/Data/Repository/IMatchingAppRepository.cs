using System.Linq.Expressions;

namespace MatchingApp.Data.Repository
{
    public interface IMatchingAppRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetById(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity);
        void CreateRange(List<TEntity> entity);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entity);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entity);
        Task SaveChangesAsync();

    }
}
