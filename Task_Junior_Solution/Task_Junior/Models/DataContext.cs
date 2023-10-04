using Microsoft.EntityFrameworkCore;

namespace Task_Junior.Models
{
    public class DataContext:DbContext
    {
        public DataContext(): base()
        {

        }
        public DataContext(DbContextOptions options):base(options)
        {
            
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category() {ID=1,Name="electroinc" },
                new Category() { ID = 2, Name = "clothes" },
                new Category() { ID = 3, Name = "Shoes" }
                );
           
       
        }
    }

}
