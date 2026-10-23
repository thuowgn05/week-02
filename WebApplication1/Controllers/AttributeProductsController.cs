using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("routing-demo/products")]
public class AttributeProductsController : Controller
{
    [HttpGet("{id:int}", Name = "AttributeProduct")]
    public IActionResult Details(int id)
    {
        return View("~/Views/RoutingExamples/Result.cshtml", new RoutingExampleViewModel
        {
            RoutingType = "Attribute Routing",
            ProductId = id
        });
    }
}
