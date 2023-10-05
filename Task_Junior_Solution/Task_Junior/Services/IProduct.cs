using Task_Junior.Models;

namespace Task_Junior.Services
{
    public interface IProduct
    {
        List<Category> GetAllcategories();
        List<Product> GetAllProductByGategoryID(int Id);

        Product GetProductByID(int ProductID);

    }
}
