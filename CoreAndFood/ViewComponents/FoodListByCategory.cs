using CoreAndFood.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class FoodListByCategory : ViewComponent
	{
		public IViewComponentResult Invoke(int id)
		{
			FoodRepository foodRepository = new FoodRepository();

			var foodlist = foodRepository.List(x=>x.CategoryId == id);
			return View(foodlist);
		}
	}
}
