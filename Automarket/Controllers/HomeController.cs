using System.Diagnostics;
using Automarket.DAL.Interfaces;
using Automarket.DAL.Repositories;
using Automarket.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Automarket.Models;

namespace Automarket.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICarRepository _carRepository;
    public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
    {
        _logger = logger;
        _carRepository = carRepository;
    }

    /*public IActionResult Index()
    {
        Car car = new Car()
        {
            Name = "Alex",
            Speed = 200
        };
        return View(car);
    }*/
    /*private readonly ICarRepository _carRepository;
    public HomeController(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }*/

    public async Task<IActionResult> Index()
    {
        var response = await _carRepository.Select();  
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Testing()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}