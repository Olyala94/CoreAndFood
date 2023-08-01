using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProductList());
        }
        
        public List<Class1> ProductList()
        {
            List<Class1> class1s = new List<Class1>();
            class1s.Add(new Class1()
            {
                ProductName = "Computer",
                Stock = 150
            });
            class1s.Add(new Class1()
            {
                ProductName="Lcd",
                Stock = 75
            });
            class1s.Add(new Class1()
            {
                ProductName= "Usb Disk",
                Stock=220
            });

            return class1s;
        }

        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<Class2> FoodList()
        {
            List<Class2> cs2 = new List<Class2>();
            using (var c = new Context())
            {
                cs2 = c.Foods.Select(x => new Class2
                {
                    foodname = x.FoodName,
                    stock = x.Stock
                }).ToList();
            }
            return cs2;
        }

        public IActionResult Statistics() 
        {
            return View();
        }
    }
}
