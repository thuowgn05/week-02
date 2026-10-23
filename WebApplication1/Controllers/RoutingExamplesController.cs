using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class RoutingExamplesController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Product(int id)
    {
        return View("Result", new RoutingExampleViewModel
        {
            RoutingType = "Conventional Routing",
            ProductId = id
        });
    }
}
