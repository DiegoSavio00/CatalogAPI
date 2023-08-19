using CatalogAPI.Validation;

namespace CatalogAPI.Domain.Entities
{
    public sealed class Category : BaseEntity
    {
        public Category(string name, string imageUrl)
        {
            ValidateDomain(name, imageUrl);
        }

        public Category(int id, string name, string imageUrl)
        {
            DomainExceptionValidation.When(id < 0, "Id value invalid!");
            Id = id;
            ValidateDomain(name, imageUrl);
        }

        public string Name { get; private set; }
        public string ImageUrl { get; private set; }
        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name, string imageUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name Invalid. Name is required");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imageUrl), "Name image is invalid. Name image is required");
            DomainExceptionValidation.When(name.Length < 3, "Namea must has mínimum 3 caracteres");
            DomainExceptionValidation.When(imageUrl.Length < 5, "Name image mus has mininum 5 caracteres");
            Name = name;
            ImageUrl = imageUrl;
        }
    }
}
