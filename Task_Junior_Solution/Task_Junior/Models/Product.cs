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
        [Required(ErrorMessage ="Enter name of product")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "select Date")]
        public DateTime CreationDate { get; set; }

        public string? Image { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "select Date")]
        public DateTime StartDate { get; set; }
        [Display(Name="Duration In Days"),Required(ErrorMessage ="Enter Duration by days")]
        public int Duration_EndDate { get; set; }
        [RegularExpression(@"^(?!0+$)[1-9]\d*$|(\d+)(\.\d{2})", ErrorMessage = "This Field must be positive, not equal zero, not contain string or string completely , and accept only two digit after dot .")]
      //  [DataType(DataType.Currency,ErrorMessage ="")]
        public double Price { get; set; }
        [ForeignKey("Category")]
        public int? Categ_Id { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("Identityuser")]
        public string? UserID { get; set; }
        public IdentityUser? Identityuser { get; set; }




    }
}
