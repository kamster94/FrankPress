namespace FrankPress.DataAccess.DataModels
{
    public class Category : BaseDataModel
    {
        private Category()
        {
        }

        public string Name { get; private set; } = null!;

        public string Slug { get; private set; } = null!;

        public static Category Create(
            int? id,
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
