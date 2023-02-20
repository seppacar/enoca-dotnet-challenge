using Microsoft.EntityFrameworkCore;
using OrderManagement.DAL.Context;
using OrderManagement.Entities.Abstract;

namespace OrderManagement.DAL.Repository.Abstract
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        // Find a better way to initalize _dbSet
        public GenericRepository()
        {
            _dbContext = new AppDbContext();
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
