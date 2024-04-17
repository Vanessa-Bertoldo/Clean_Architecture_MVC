using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product //O sealed faz com que essa classe não possa ser herdada
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 charecters");

            DomainExceptionValidation.When(price < 3, "Invalid price value");

            DomainExceptionValidation.When(stock < 3, "Invalid stock value");

            DomainExceptionValidation.When(image.Length > 250, "Invalid name. Name is required");
        }

        //As propriedades de navegação não ficam com o set privado por não fazerem parte da estrutura de dominio
        public int CategoryId { get; set; }
        public Category Category { get;  set; }
    }
}
