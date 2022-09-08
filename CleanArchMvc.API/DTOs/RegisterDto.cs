using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.API.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid format email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
