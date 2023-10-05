using Microsoft.CodeAnalysis;
using Task_Junior.Models;

namespace Task_Junior.Services
{
    public class ProductRepo : Repostory<Product>,IProduct
    {
        private readonly DataContext db;

        public IWebHostEnvironment WebHost { get; }

        public ProductRepo(DataContext _db,IWebHostEnvironment webHost):base(_db)
        {
            db = _db;
            WebHost = webHost;
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

        public string UploadFile(IFormFile image)
        {

            string uploadsFolder = Path.Combine(WebHost.WebRootPath, "Images");
            string ImageName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, ImageName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return ImageName;

        }


    }
}
