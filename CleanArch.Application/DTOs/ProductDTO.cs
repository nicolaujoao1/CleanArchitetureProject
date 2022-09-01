using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "This description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Description")]
        public string? Description { get;  set; }
        [Required(ErrorMessage = "This price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "This stock is required")]
        [Range(1,9999)]
        [DisplayName("Stock")]
        public int Stock { get;  set; }
        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string? Image { get;  set; }
        public Category? Category { get; set; }
        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}
