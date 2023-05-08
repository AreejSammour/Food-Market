using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Food_Market.Models;

namespace Food_Market.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}

