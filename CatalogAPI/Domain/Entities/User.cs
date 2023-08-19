using CatalogAPI.Validation;

namespace CatalogAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password)
        {
            ValidateDomain(name, email, password);
        }

        public User(int id, string name, string email, string password)
        {
            DomainExceptionValidation.When(id <= 0, "Id is required!");
            Id = id;
            ValidateDomain(name, email, password);
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private void ValidateDomain(string name, string email, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Enter the name User");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Enter the email User");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Enter the password User");
            Name = name;
            Email = email;
            Password = password;
        }


    }
}
