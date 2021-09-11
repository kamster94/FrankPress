namespace FrankPress.DataAccess.DataModels
{
    public class Category
    {
        private Category()
        {
        }

        public int Id { get; private set; }

        public string Name { get; private set; } = null!;

        public string Slug { get; private set; } = null!;

        public static Category Create(
            int id,
            string name,
            string slug) =>
            new Category()
            {
                Id = id,
                Name = name,
                Slug = slug
            };
    }
}
