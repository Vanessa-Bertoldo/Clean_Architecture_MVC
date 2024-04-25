using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            ValidateIdAnedNameCategory(id, name);
            Id = id;
            Name = name;
        }
        public ICollection<Product> Products { get; private set; }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecters");
            Name = name;
        }

        private void ValidateIdAnedNameCategory(int Id, string name)
        {
            DomainExceptionValidation.When(Id < 1, "Invalid Id Value");
            ValidateDomain(name);
        }
    }
}
