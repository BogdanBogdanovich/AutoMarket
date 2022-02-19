using System.Net;
using Automarket.Domain.Entity;
using Automarket.Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Automarket.Models;
using Automarket.Service.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Automarket.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }
    // GET
    [HttpGet]
    public IActionResult Registration()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Registration(string name, string surname, string phonenumber, string email, string password, string repiatpass)
    {
        var checkUser = await _userService.GetUsers();
        var complete = checkUser.Data.FirstOrDefault(x => x.Email == email);
        if (complete == null)
        {
            var newUser = new UserViewModel()
            {
                Name = name,
                Surname = surname,
                PhoneNumber = phonenumber,
                Email = email,
                Password = password
            };
            await _userService.CreateUser(newUser);
            /*return RedirectToAction("Authorization");*/
            checkUser = await _userService.GetUsers();
            complete = checkUser.Data.FirstOrDefault(y => y.Email == email && y.Password == password);
            if (complete != null)
            {
                return RedirectToAction("Authorization");
            }
        }
        else
        {
            ModelState.AddModelError("","Пользователь с таким логином уже существует");
            checkUser.Description = "Пользователь с таким логином уже существует";
        }
        return View();
    }
    [HttpGet]
    public IActionResult Authorization()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Authorization(string email, string password)
    {
        var authorization = await _userService.GetUsers();
        var complete = authorization.Data.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        if (complete != null)
        {
            return RedirectToRoute(new { controller="Home", action="Index"});
        }
        else
        {
            authorization.Description = "Такого пользователя не существует";
            return View();
        }
    }
}