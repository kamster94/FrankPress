namespace FrankPress.Domain.DomainModels
{
    public record User
    {
        private User()
        {
        }

        public int Id { get; init; }

        public string Email { get; init; } = null!;

        public string Name { get; init; } = null!;

        public string LastName { get; init; } = null!;

        public string DisplayName { get; init; } = null!;

        public Role UserRole { get; init; } = null!;

        public IdentityProvider IdentityProvider { get; init; } = null!;

        public bool UseGravatar { get; init; }

        public static User Create(
            int id,
            string email,
            string name,
            string lastName,
            string displayName,
            Role userRole,
            IdentityProvider identityProvider,
            bool useGravatar) =>
            new User()
            {
                Id = id,
                Email = email,
                Name = name,
                LastName = lastName,
                DisplayName = displayName,
                UserRole = userRole,
                IdentityProvider = identityProvider,
                UseGravatar = useGravatar
            };
    }
}
