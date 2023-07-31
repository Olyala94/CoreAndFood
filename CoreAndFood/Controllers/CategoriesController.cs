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

        //public IActionResult CategoriesDelete(int id)
        //{
        //    categoryrepository.TDelete(id);
        //    return RedirectToAction("Index");
        //}
    }
}
