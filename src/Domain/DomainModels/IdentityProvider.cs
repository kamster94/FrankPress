namespace FrankPress.Domain.DomainModels
{
    public record IdentityProvider
    {
        private IdentityProvider()
        {
        }

        public int Id { get; init; }

        public string Name { get; init; } = null!;

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
