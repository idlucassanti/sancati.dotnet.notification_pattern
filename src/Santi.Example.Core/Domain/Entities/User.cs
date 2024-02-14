using Santi.Example.Core.Validatros;

namespace Santi.Example.Core.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string email, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;

            Validate(this, new UserValidator());
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
