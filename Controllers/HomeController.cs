using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoutingNet8.Models;

namespace RoutingNet8.Controllers;

//[Route("[controller]/[action]")]
[Route("home")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }
    [Route("index/{id:int?}/{x?}/{y?}")]
    public IActionResult Index(string id, string x, string y)
    {
        System.Console.WriteLine("id: "+ id + ", x: " + x + ", y: " + y);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
