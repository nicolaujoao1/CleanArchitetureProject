using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1,"Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName ="With Negative Name")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>();
        }
        [Fact(DisplayName ="With Null Name Value")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>();  
        }
        [Fact(DisplayName ="Minimum characters")]
        public void CreateCategory_WithMinumCharacter_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "ca");
            action.Should().Throw<DomainExceptionValidation>();
        }
        [Fact(DisplayName ="Missing Name Value")]
        public void CreateCategory_MissingNameValue_DomainExcepetionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}