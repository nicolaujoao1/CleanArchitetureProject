using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CleanArch.WebUI.Blazor.Models;
public class ProductDto
{
    public int Id { get; set; }
    [Required(ErrorMessage = "This name is required")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "This description is required")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "This price is required")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }
    [Required(ErrorMessage = "This stock is required")]
    [Range(1, 9999)]
    [DisplayName("Stock")]
    public int Stock { get; set; }
    [MaxLength(250)]
    [DisplayName("Product Image")]
    public string? Image { get; set; }
    //[JsonIgnore]
    public CategoryDto? Category { get; set; }
    [DisplayName("Categories")]
    public int CategoryId { get; set; }
}
