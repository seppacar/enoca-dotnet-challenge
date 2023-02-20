using OrderManagement.Entities.Abstract;

namespace OrderManagement.DAL.Repository.Abstract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
