using System;

namespace FrankPress.DataAccess.DataModels
{
    public class Media : BaseDataModel
    {
        private Media()
        {
        }

        public MediaType MediaType { get; private set; } = null!;

        public DateTime PublishedDate { get; private set; }

        public string Filename { get; private set; } = null!;

        public static Media Create(
            int? id,
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
