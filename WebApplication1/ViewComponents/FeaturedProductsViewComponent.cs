using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.ViewComponents;

public class FeaturedProductsViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(int count)
    {
        // Dữ liệu mẫu; ứng dụng thực tế có thể lấy qua service được inject.
        var products = new[]
        {
            new ProductViewModel
            {
                Name = "Sách ASP.NET Core",
                Description = "Học cách xây dựng ứng dụng web theo mô hình MVC.",
                Price = 180000m
            },
            new ProductViewModel
            {
                Name = "Sách C# cơ bản",
                Description = "Làm quen với lập trình hướng đối tượng bằng C#.",
                Price = 120000m
            },
            new ProductViewModel
            {
                Name = "Bộ bài tập Razor",
                Description = "Thực hành View, Partial View và View Component.",
                Price = 75000m
            }
        };

        var selectedProducts = products
            .OrderBy(product => product.Price)
            .Take(Math.Clamp(count, 0, products.Length))
            .ToArray();

        return View(selectedProducts);
    }
}
