using CoreAndFood.Data.Models;
using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class CategoriesController : Controller
    {
        CategoryRepository categoryrepository = new CategoryRepository();

        public IActionResult Index()
        {
           return View(categoryrepository.TList());
        }

        [HttpGet]
        public IActionResult CategoriesAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoriesAdd(Category p)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoriesAdd");
            }
            categoryrepository.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult CategoriesGet(int id)
        {
            var values = categoryrepository.TGetList(id);
            Category category = new Category()
            {
                CategoryName = values.CategoryName,
                Description = values.Description,   
                CategoryId = values.CategoryId      
            };
            return View(category);
        }

        [HttpPost]
        public IActionResult CategoriesUpdate(Category p)
        {
            var x = categoryrepository.TGetList(p.CategoryId);
            x.CategoryName = p.CategoryName;
            x.Description = p.Description;
            x.Status = true;
            categoryrepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoriesDelete(int id)
        {
            var x = categoryrepository.TGetList(id);
            x.Status = false;
            categoryrepository.TUpdate(x);

            return RedirectToAction("Index");
        }
    }
}
