using CleanArch.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Entities
{
    public sealed class Product:Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string? Image { get; private set; }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, $"Invalid Id={id} value");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name,description,price,stock,image);
            //Name = name;
            //Description = description;
            //Price = price;
            //Stock = stock;
            //Image = image;
            //CategoryId = categoryId;
            //Category = category;
        }
        public void Update(string name,string description,decimal price,int stock, string image,int categoryId)
        {
            ValidateDomain(name,description,price,stock,image);
            CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock,string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");
            DomainExceptionValidation.When(name.Length<3, "Invalid name, too short, minimum 3 characters") ;
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, description is required");
            DomainExceptionValidation.When(price <0, "Invalid price, Invalid price value");
            DomainExceptionValidation.When(stock < 0, "Invalid stock, Invalid stock value");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, maximum 250 characters.");
            Name = name;
            Description = description;  
            Price = price;  
            Stock = stock;  
            Image = image;
        }
        public int CategoryId { get;  set; }
        public Category? Category { get; set; }
    }
}
