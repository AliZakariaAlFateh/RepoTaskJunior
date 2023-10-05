using Microsoft.CodeAnalysis;
using Task_Junior.Models;

namespace Task_Junior.Services
{
    public class ProductRepo : Repostory<Product>,IProduct
    {
        private readonly DataContext db;

        public ProductRepo(DataContext _db):base(_db)
        {
            db = _db;
        }
        public List<Product> GetAllProductByGategoryID(int id)
        {
            var query = db.Products.Where(c=>c.Categ_Id==id).ToList();
            return query;
        }
        public List<Category> GetAllcategories()
        
        {
            var query = db.Categories.ToList();
            return  query;
        }
        public Category GetCategoryName(int ProductId)
        {
            return db.Categories.Find(ProductId);
        }

         public Product GetProductByID(int ProductID)
        {
            Product Prod= db.Products.Find(ProductID);
            if (Prod != null)
            {
                DateTime EndDate = Prod.StartDate.AddDays(Prod.Duration_EndDate);
                if (Prod.StartDate <= DateTime.Now && EndDate >= DateTime.Now)
                     return Prod;
            }
            return null;

        }

        
    }
}
