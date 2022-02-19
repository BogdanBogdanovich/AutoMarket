using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.User;
using Automarket.Service.Interfaces;

namespace Automarket.Service.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IBaseResponse<IEnumerable<User>>> GetUsers()
    {
        var baseResponse = new BaseResponse<IEnumerable<User>>();
        try
        {
            var users = await _userRepository.Select();
            if (users.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            baseResponse.Data = users;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<User>>()
            {   
                Description = $"{GetUsers()} : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<User>> GetUser(int idUser)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = await _userRepository.Get(idUser);
            if (user == null)
            {
                baseResponse.Description = "Пользователь не найден";
                baseResponse.StatusCode = StatusCode.ElementNoFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<User>()
            {
                Description = $"{GetUser(idUser)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<User>> GetByName(string name)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = await _userRepository.GetByName(name);
            if (user == null)
            {
                baseResponse.Description = "Пользователь не найден";
                baseResponse.StatusCode = StatusCode.ElementNoFound;
                return baseResponse;
            }

            baseResponse.Data = user;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<User>()
            {
                Description = $"{GetByName(name)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteUser(int idUser)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var user = await _userRepository.Get(idUser);
            if (user == null)
            {
                baseResponse.Description = "Пользователь не найден";
                baseResponse.StatusCode = StatusCode.ElementNoFound;
                return baseResponse;
            }

            await _userRepository.Delete(user);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = $"{DeleteUser(idUser)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<User>> CreateUser(UserViewModel userViewModel)
    {
        var baseResponse = new BaseResponse<User>();
        try
        {
            var user = new User()
            {
                /*idUser = 0,*/
                Name = userViewModel.Name,
                Surname = userViewModel.Surname,
                PhoneNumber = userViewModel.PhoneNumber,
                Email = userViewModel.Email,
                Password = userViewModel.Password
            };
            await _userRepository.Create(user);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<User>()
            {
                Description = $"{CreateUser(userViewModel)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}