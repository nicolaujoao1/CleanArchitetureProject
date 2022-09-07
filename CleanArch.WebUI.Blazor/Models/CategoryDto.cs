using System.ComponentModel.DataAnnotations;

namespace CleanArch.WebUI.Blazor.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This name is required")]
        [MaxLength(100)]
        [MinLength(3)]
        public string? Name { get; set; }
    }
}
