using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;


namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName ="Create Product With Valid Parameters")]
        public void CreateProduct_WithValidParameters_ReturnObjectValidState()
        {
            Action action = () => new Product(1, "Maça", "Para comer", 180m, 12, "image path");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName ="Negative Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Maça", "Para comer", 180m, 12, "image path");
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}
