﻿using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity//O sealed faz com que essa classe não possa ser herdada
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image) {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int Id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(Id < 0, "invalid Id value");
            Id = Id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoriaId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoriaId;
        }


        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 charecters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description. description is required");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 charecters");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price; 
            Stock = stock;
            Image = image;
        }

        //As propriedades de navegação não ficam com o set privado por não fazerem parte da estrutura de dominio
        public int CategoryId { get; set; }
        public Category Category { get;  set; }
    }
}
