namespace FrankPress.DataAccess.DataModels
{
    public class Article
    {
        private Article()
        {
        }

        public int Id { get; private set; }

        public string Title { get; private set; } = null!;

        public User Author { get; private set; } = null!;

        public Category Category { get; private set; } = null!;

        public IEnumerable<Tag>? Tags { get; private set; }

        public string Permalink { get; private set; } = null!;

        public Media? CoverImage { get; private set; }

        public string? SeoKeyphrase { get; private set; }

        public string? Content { get; private set; }

        public DateTime PublishedDate { get; private set; }

        public DateTime ModifiedDate { get; private set; }

        public static Article Create(
            int id,
            string title,
            User author,
            Category category,
            IEnumerable<Tag>? tags,
            string permalink,
            Media? coverImage,
            string? seoKeyphrase,
            string? content,
            DateTime publishedDate,
            DateTime modifiedDate) =>
            new Article()
            {
                Id = id,
                Title = title,
                Author = author,
                Category = category,
                Tags = tags,
                Permalink = permalink,
                CoverImage = coverImage,
                SeoKeyphrase = seoKeyphrase,
                Content = content,
                PublishedDate = publishedDate,
                ModifiedDate = modifiedDate
            };
    }
}
