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
                ProductName = "Lcd",
                Stock = 75
            });
            class1s.Add(new Class1()
            {
                ProductName = "Usb Disk",
                Stock = 220
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
            Context c = new Context();
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2 = c.Categories.Count();
            ViewBag.d2 = deger2;

            var foid = c.Categories.Where(X => X.CategoryName == "Fruit").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.d = foid;

            var deger3 = c.Foods.Where(x => x.CategoryId == foid).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(x => x.CategoryId == c.Categories.Where(z => z.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = deger5;

            var deger6 = c.Foods.Where(x => x.CategoryId == c.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryId).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7 = c.Foods.OrderByDescending(x=>x.Stock).Select(y=>y.FoodName).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Foods.OrderBy(x=>x.Stock).Select(z=>z.FoodName).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;    

            var deger10 = c.Categories.Where(x=>x.CategoryName=="Fruit").Select(y=>y.CategoryId).FirstOrDefault();
            var deger10p = c.Foods.Where(y => y.CategoryId == deger10).Sum(x => x.Stock);
            ViewBag.d10 = deger10p;

            var deger11 = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryId).FirstOrDefault();
            var deger11p = c.Foods.Where(y => y.CategoryId == deger11).Sum(x => x.Stock);
            ViewBag.d11 = deger11p;


            var deger12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d12 = deger12;

            return View();
        }
    }
}
