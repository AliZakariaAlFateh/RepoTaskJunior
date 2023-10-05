using System.ComponentModel.DataAnnotations;

namespace Task_Junior.ViewModel
{
    public class UserVM
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password Not Matched")]
        public string ConfirmPassword { get; set; }

        public string RoleName { get; set; }
    }

}
