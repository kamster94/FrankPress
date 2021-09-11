namespace FrankPress.DataAccess.DataModels
{
    public class IdentityProvider
    {
        private IdentityProvider()
        {
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = null!;

        public static IdentityProvider Create(
            int id,
            string name) =>
            new IdentityProvider()
            {
                Id = id,
                Name = name
            };
    }
}
