namespace FrankPress.DataAccess.DataModels
{
    public class Tag : BaseDataModel
    {
        private Tag()
        {
        }

        public string Name { get; private set; } = null!;

        public string Slug { get; private set; } = null!;

        public static Tag Create(
            int? id,
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
