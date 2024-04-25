using CleanArchMvc.Domain.Entities;
using FluentAssertions;
namespace CleanArchMvc.Domain.Tests
{
    [TestClass]
    public class ProductUnitTest
    {
        [TestMethod(displayName: "Create Product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            // Define uma ação (método sem argumentos e sem retorno) que cria uma nova instância da classe Category
            Action action = () => new Product(1, "Product Name", "Product description", 99.99m, 99, "Product image");

            // Ao realizar o teste a excessão não deve ser lançada no dominio
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [TestMethod(displayName: "Create Product with negative id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 99.99m, 99, "Product image");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>(); 

        }


        [TestMethod(displayName: "Create Product with short name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(-1, "Pr", "Product description", 99.99m, 99, "Product image");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [TestMethod(displayName: "Create Product with null image value")]
        public void CreateProduct_NullImageValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 99.99m, 99, null);

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }


        [TestMethod(displayName: "Create Product with null image value")]
        public void CreateProduct_InvalidStockValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", 99.99m, -5, "product image");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [TestMethod(displayName: "Create Product with negative price value")]
        public void CreateProduct_InvalidPriceValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(-1, "Product Name", "Product description", -99.99m, -5, "product image");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

    }
}
