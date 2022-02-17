using Automarket.DAL.Interfaces;
using Automarket.Domain.Entity;
using Automarket.Domain.Enum;
using Automarket.Domain.Response;
using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;

namespace Automarket.Service.Implementations;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }


    public async Task<IBaseResponse<Car>> GetCar(int id)
    {
        var baseResponse = new BaseResponse<Car>();
        try
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                baseResponse.Description = "Элемент не найден";
                baseResponse.StatusCode = StatusCode.ElementNoFound;
                return baseResponse;
            }

            baseResponse.Data = car;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Car>()
            {
                Description = $"{GetCar(id)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<Car>> GetByName(string name)
    {
        var baseResponse = new BaseResponse<Car>();
        try
        {
            var car = await _carRepository.GetByName(name);
            if (car == null)
            {
                baseResponse.Description = "Элемент не найден";
                baseResponse.StatusCode = StatusCode.ElementNoFound;
                return baseResponse;
            }

            baseResponse.Data = car;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<Car>()
            {
                Description = $"{GetByName(name)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<bool>> DeleteCar(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                baseResponse.Description = "Элемент не найден";
                baseResponse.StatusCode = StatusCode.ElementNoFound;
                return baseResponse;
            }

            await _carRepository.Delete(car);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<bool>()
            {
                Description = $"{DeleteCar(id)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
    {
        var baseResponse = new BaseResponse<CarViewModel>();
        try
        {
            var car = new Car()
            {
                Name = carViewModel.Name,
                Description = carViewModel.Description,
                Model = carViewModel.Model,
                Speed = carViewModel.Speed,
                Price = carViewModel.Price,
                DateCreate = carViewModel.DateCreate,
                TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
            };
            await _carRepository.Create(car);
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<CarViewModel>()
            {
                Description = $"{CreateCar(carViewModel)}: {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }

    public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
    {
        var baseResponse = new BaseResponse<IEnumerable<Car>>();
        try
        {
            var cars = await _carRepository.Select();
            if (cars.Count == 0)
            {
                baseResponse.Description = "Найдено 0 элементов";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            baseResponse.Data = cars;
            baseResponse.StatusCode = StatusCode.OK;
            return baseResponse;
        }
        catch (Exception ex)
        {
            return new BaseResponse<IEnumerable<Car>>()
            {   
                Description = $"{GetCars()} : {ex.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}