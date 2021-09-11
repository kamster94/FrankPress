namespace FrankPress.DataAccess.DataModels
{
    public class User
    {
        private User()
        {
        }

        public int Id { get; private set; }

        public string Email { get; set; } = null!;

        public string Name {  get; private set; } = null!;

        public string LastName { get; private set; } = null!;

        public string DisplayName {  get; private set; } = null!;

        public Role UserRole { get; set; } = null!;

        public IdentityProvider IdentityProvider { get; private set; } = null!;

        public bool UseGravatar { get; private set; }

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
