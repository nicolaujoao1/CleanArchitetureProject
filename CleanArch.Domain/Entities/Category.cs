using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category:Entity
    {
        public string? Name { get; private set; }
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public void Update(string name) {
            ValidateDomain(name);   
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id<0,"Invalid Id value.") ;
            Id = id; 
            ValidateDomain(name);
        }
        public ICollection<Product>? Products { get;  set; }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is requires");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minumum 3 characters");
            Name = name;
        }
    }
}
