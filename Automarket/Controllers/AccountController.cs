using Microsoft.AspNetCore.Mvc;
using Automarket.Models;
using Microsoft.EntityFrameworkCore;


namespace Automarket.Controllers;

public class AccountController : Controller
{
    
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }
    // GET
    public IActionResult Registration()
    {
        
        return View();
    }
    
    public IActionResult Authorization()
    {
        return View();
    }
}