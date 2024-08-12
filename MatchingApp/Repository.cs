using MatchingApp.Data;
using MatchingApp.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MatchingApp
{
    public class Repository<Tentity> : IRepository<Tentity> where Tentity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
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
            return _dbContext.Set<Tentity>();
        }

        public IQueryable<Tentity> GetByCondition(Expression<Func<Tentity, bool>> expression)
        {
            return _dbContext.Set<Tentity>().Where(expression);
        }

        public IQueryable<Tentity> GetById<Tkey>(Tkey id)
        {
            // Assuming the ID property is named "Id"
            return _dbContext.Set<Tentity>().Where(e => EF.Property<Tkey>(e, "Id")!.Equals(id));
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
