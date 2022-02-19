using Automarket.Domain.Entity;

namespace Automarket.DAL.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?>GetByName(string name);
}