using MatchingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MatchingApp.Data.Repository
{
    public class MatchingRepository<Tentity> : IMatchingRepository<Tentity> where Tentity : class
    {
        private ApplicationDbContext _dbContext;
        public MatchingRepository(ApplicationDbContext context) 
        {
            _dbContext = context;
        }

        public void Create(Tentity entity)
        {
            _dbContext.Set<Tentity>().Add(entity);
        }

        public void CreateRange(List<Tentity> entities)
        {
            _dbContext.Set<Tentity>().AddRange(entities);
        }

        public void Delete(Tentity entity)
        {
            _dbContext.Set<Tentity>().Remove(entity);
        }

        public void DeleteRange(List<Tentity> entities)
        {
            _dbContext.Set<Tentity>().RemoveRange(entities);
        }

        public IQueryable<Tentity> GetAll()
        {
            var result = _dbContext.Set<Tentity>();

            return result;
        }

        public IQueryable<Tentity> GetByCondition(Expression<Func<Tentity, bool>> expression)
        {
            return _dbContext.Set<Tentity>().Where(expression);
        }

        public IQueryable<Tentity> GetById(Expression<Func<Tentity, bool>> expression)
        {
            return _dbContext.Set<Tentity>().Where(expression);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(Tentity entity)
        {
            _dbContext.Set<Tentity>().Update(entity);
        }

        public void UpdateRange(List<Tentity> entities)
        {
            _dbContext.Set<Tentity>().UpdateRange(entities);
        }


    }
}
