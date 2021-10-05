namespace FrankPress.Domain.DomainModels
{
    public record Role
    {
        private Role()
        {
        }

        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public static Role Create(
            int id,
            string name) =>
            new Role()
            {
                Id = id,
                Name = name
            };
    }
}
