namespace Task_Junior.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Courses { get; set; }
    }
}
