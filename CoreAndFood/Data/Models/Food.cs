using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
    public class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public int Stock { get; set; }

        //Burada ise sadece bir food'ın sadece bir tane Category'sinin olacagını bildirdik
        public int CategoryId { get; set; }

        //Category sınıfından türetmiş olduk 
        public virtual Category Category { get; set; }
    }
}
