namespace FrankPress.DataAccess.DataModels
{
    public class Media
    {
        private Media()
        {
        }

        public int Id { get; private set; }

        public MediaType MediaType { get; private set; } = null!;

        public DateTime PublishedDate { get; private set; }

        public string Filename { get; private set; } = null!;

        public static Media Create(
            int id,
            MediaType mediaType,
            DateTime publishedDate,
            string filename) =>
            new Media()
            {
                Id = id,
                MediaType = mediaType,
                PublishedDate = publishedDate,
                Filename = filename
            };
    }
}
