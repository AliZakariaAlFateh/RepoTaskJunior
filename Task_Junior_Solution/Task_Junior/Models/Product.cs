using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Junior.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
       // public int UserID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime MyProperty { get; set; }
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int? Categ_Id { get; set; }
        public Category Category { get; set; }
        


    }
}
