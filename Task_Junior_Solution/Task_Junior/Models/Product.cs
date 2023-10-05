using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Junior.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]

        public DateTime CreationDate { get; set; }
        // public int UserID { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Duration_EndDate { get; set; }
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int? Categ_Id { get; set; }
        public Category? Category { get; set; }
        


    }
}
