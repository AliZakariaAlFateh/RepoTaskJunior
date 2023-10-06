using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task_Junior.Migrations;

namespace Task_Junior.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public string? Image { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        //[DataType(DataType.DateTime)]
        [Display(Name="Duration In Days")]
        public int Duration_EndDate { get; set; }
        [RegularExpression(@"^(?!0+$)[1-9]\d*$|(\d+)(\.\d{2})", ErrorMessage = "This Field must be positive, not equal zero, not contain string or string completely , and accept only two digit after dot .")]
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int? Categ_Id { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("Identityuser")]
        public string? UserID { get; set; }
        public IdentityUser? Identityuser { get; set; }




    }
}
