using CoreAndFood.Data.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context();  

        public IActionResult Index()
        {
            FoodRepository foodRepository = new FoodRepository();   

            return View(foodRepository.TList("Category"));
        }

        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString(),
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(Food p)
        {
            return View();
        }
    }
}
