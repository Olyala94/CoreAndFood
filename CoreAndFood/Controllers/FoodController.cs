using CoreAndFood.Data.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        Context c = new Context(); 

        FoodRepository foodRepository = new FoodRepository(); 

        public IActionResult Index(int page=1)
        {  
            return View(foodRepository.TList("Category").ToPagedList(page, 3));
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
        public IActionResult AddFood(urunekle p)
        {
            Food f = new Food();
            if(p != null)
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;  
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageURL.CopyTo(stream);
                f.ImageURL = newimagename;
            }
            f.FoodName= p.FoodName;
            f.Price = p.Price;
            f.Stock = p.Stock;
            f.CategoryId = p.CategoryId;
            f.Description = p.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFood(int id)
        {
          
            foodRepository.TDelete(new Food { FoodId = id });
            return RedirectToAction("Index");   
        }

        public IActionResult FoodGet(int id)
        {
            var values = foodRepository.TGetList(id);

            List<SelectListItem> value = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryId.ToString(),
                                           }).ToList();
            ViewBag.v1 = value;

            Food food = new Food()
            {
                FoodId = values.FoodId,
                CategoryId = values.CategoryId,
                FoodName = values.FoodName, 
                Price = values.Price,   
                Stock = values.Stock,
                Description = values.Description,
                ImageURL    = values.ImageURL
            };

            return View(food);
        }
        [HttpPost]
        public IActionResult FoodUpdate(Food p)
        {
            var values = foodRepository.TGetList(p.FoodId);
            values.FoodName = p.FoodName;
            values.Stock    = p.Stock;
            values.Price    = p.Price;
            values.ImageURL = p.ImageURL;
            values.Description = p.Description;
            values.CategoryId = p.CategoryId;

            foodRepository.TUpdate(values);
            return RedirectToAction("Index");  
        }
    }
}
