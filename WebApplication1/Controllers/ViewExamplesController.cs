using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class ViewExamplesController : Controller
{
    public IActionResult Index()
    {
        var product = new ProductViewModel
        {
            Name = "Sổ tay học MVC",
            Description = "Dữ liệu mẫu do controller chuẩn bị và truyền cho Partial View.",
            Price = 45000m
        };

        return View(product);
    }
}
