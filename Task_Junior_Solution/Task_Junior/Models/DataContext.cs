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
    }

}
