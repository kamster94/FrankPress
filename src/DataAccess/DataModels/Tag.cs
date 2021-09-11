namespace FrankPress.DataAccess.DataModels
{
    public class Tag
    {
        private Tag()
        {
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = null!;

        public string Slug { get; private set; } = null!;

        public static Tag Create(
            int id,
            string name,
            string slug) =>
            new Tag()
            {
                Id = id,
                Name = name,
                Slug = slug
            };
    }
}
