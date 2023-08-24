namespace CoreAndFood.Data.Models
{
    public class urunekle
    {
        public string FoodName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public IFormFile ImageURL { get; set; }

        public int Stock { get; set; }

        //Burada ise sadece bir food'ın sadece bir tane Category'sinin olacagını bildirdik
        public int CategoryId { get; set; }
    }
}
