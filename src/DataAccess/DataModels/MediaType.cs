namespace FrankPress.DataAccess.DataModels
{
    public class MediaType : BaseDataModel
    {
        private MediaType()
        {
        }

        public string Name { get; private set; } = null!;

        public static MediaType Create(
            int? id,
            string name) =>
            new MediaType()
            {
                Id = id,
                Name = name
            };
    }
}
