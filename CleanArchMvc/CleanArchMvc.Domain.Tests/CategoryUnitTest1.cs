using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    [TestClass]
    public class CategoryUnitTest1
    {
        [TestMethod(displayName: "Create Category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            // Define uma ação (método sem argumentos e sem retorno) que cria uma nova instância da classe Category
            Action action = () => new Category(1, "Category Name");

            // Ao realizar o teste a excessão não deve ser lançada no dominio
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [TestMethod(displayName: "Create Category with negative id")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>(); //.WithMessage("Invalid Id Value"); Mensagem esperada da excessão

        }

        [TestMethod(displayName: "Create Category with short name")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }

        [TestMethod(displayName: "Create Category with missing name value")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [TestMethod(displayName: "Create Category with null name value")]
        public void CreateCategory_MissingNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);

            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }
    }
}