using System.Linq.Expressions;

namespace DevApplication.Repository.IRepository
{
  
        public interface IRepository<T> where T : class
        {
                T FirstOrDefault(Expression<Func<T, bool>> filter);
                IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null);
                void Add(T entity);
                void Remove(T entity);
                void RemoveRange(IEnumerable<T> entity);
        }
    
}
