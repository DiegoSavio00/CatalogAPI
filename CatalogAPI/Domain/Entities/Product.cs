using CatalogAPI.Validation;

namespace CatalogAPI.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public Product(string name, string description, decimal price, string imageUrl, DateTime registerDate)
        {
            ValidateDomain(name, description, price, imageUrl, registerDate);
        }

        public Product(string name, string description, decimal price, string imageUrl, DateTime registerDate, int categoryId)
        {
            ValidateDomain(name, description, price, imageUrl, registerDate);
            CategoryId = categoryId;

        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, string imageUrl, DateTime registerDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name invalid! Name is required");
            DomainExceptionValidation.When(name.Length < 3, "Name product must has minimum 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description invalid! Description is required");
            DomainExceptionValidation.When(description.Length < 5, "Description must has mininum 5 caracteres");
            DomainExceptionValidation.When(price < 0, "Value price is invalid!");
            DomainExceptionValidation.When(imageUrl?.Length > 250, "The name of image does not exceed 250 caracteres");
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            RegisterDate = registerDate;
        }
    }
}
