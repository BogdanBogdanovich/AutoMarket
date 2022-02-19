using Automarket.Domain.Entity;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Domain.ViewModels.User;

namespace Automarket.Service.Interfaces;

public interface IUserService
{
    Task<IBaseResponse<IEnumerable<User>>> GetUsers();
    Task<IBaseResponse<User>> GetUser(int idUser);
    Task<IBaseResponse<User>> GetByName(string name);
    Task<IBaseResponse<bool>> DeleteUser(int idUser);
    Task<IBaseResponse<User>> CreateUser(UserViewModel userViewModel);
}