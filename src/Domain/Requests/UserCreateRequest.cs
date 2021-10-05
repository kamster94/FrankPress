using FrankPress.Domain.DomainModels;

namespace FrankPress.Domain.Requests
{
    public class UserCreateRequest
    {
        public string Email { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public Role UserRole { get; set; } = null!;

        public IdentityProvider IdentityProvider { get; set; } = null!;
    }
}
