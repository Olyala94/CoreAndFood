using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Data.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=CoreFoodDb; integrated security=true;");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Food> Foods { get; set; }  

        public DbSet<Admin> Admins { get; set; }
    }
}
