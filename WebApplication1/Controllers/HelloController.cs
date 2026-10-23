using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class HelloController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public string Welcome(string name, int ID = 1)
    {
        return HtmlEncoder.Default.Encode($"Hello: {name}!, numTimes is: {ID}");
    }
}
