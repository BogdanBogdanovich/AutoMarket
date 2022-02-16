using Automarket.Domain.Entity;

namespace Automarket.DAL.Interfaces;

public interface IBaseRepository<T>
{
    bool Create(T entity);

    T Get(int id);

    Task<List<Car>> Select();

    bool Delete(T entity);
    
    
}