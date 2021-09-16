using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Enums;
using FrankPress.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Test.Repositories
{
    public class ArticleRepositoryTest : BaseRepositoryTest<Article>
    {
        public ArticleRepositoryTest()
        {
            Repository = new ArticleRepository(_databaseContext);
            GetEntityAsync = GetArticle;
        }

        [Fact]
        public async Task Get_ShouldReturnArticle() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateArticle() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteArticle() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnArticles() => await GetAll_Test();

        [Fact]
        public async Task GetByAuthor_ShouldReturnArticle()
        {
            //Arrange
            var article = await GetArticle();
            article = await Repository!.Save(article);

            //Act
            var results = await ((ArticleRepository)Repository!).GetByAuthor((int)article.Author.Id!);

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(article, results);
        }

        [Fact]
        public async Task GetByCategory_ShouldReturnArticle()
        {
            //Arrange
            var article = await GetArticle();
            article = await Repository!.Save(article);

            //Act
            var results = await ((ArticleRepository)Repository!).GetByCategory((int)article.Category.Id!);

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(article, results);
        }

        [Fact]
        public async Task GetByTags_ShouldReturnArticle()
        {
            //Arrange
            var article = await GetArticle();
            article = await Repository!.Save(article);

            //Act
            var results = await ((ArticleRepository)Repository!).GetByTags(new List<int> { (int)article.Tags!.First().Id! });

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(article, results);
        }

        [Theory, MemberData(nameof(TestDates))]
        public async Task GetByPublishedDate_ShouldReturnArticle(DateTime date, ComparisonOperator comparisonOperator)
        {
            //Arrange
            var article = await GetArticle();
            article = await Repository!.Save(article);

            //Act
            var results = await ((ArticleRepository)Repository!).GetByPublishedDate(date, comparisonOperator);

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(article, results);
        }

        [Theory, MemberData(nameof(TestDates))]
        public async Task GetByModifiedDate_ShouldReturnArticle(DateTime date, ComparisonOperator comparisonOperator)
        {
            //Arrange
            var article = await GetArticle();
            article = await Repository!.Save(article);

            //Act
            var results = await ((ArticleRepository)Repository!).GetByModifiedDate(date, comparisonOperator);

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(article, results);
        }

        private static IEnumerable<object[]> TestDates()
        {
            yield return new object[] { DateTime.Today.AddDays(1), ComparisonOperator.LessThan };
            yield return new object[] { DateTime.Today.AddDays(-1), ComparisonOperator.GreaterThan };
            yield return new object[] { DateTime.Today, ComparisonOperator.Equal };
        }

        protected async Task<Article> GetArticle(int? id = null, string? title = null)
        {
            var role = Role.Create(
                id: null,
                name: "TestName");
            role = await new RoleRepository(_databaseContext).Save(role);

            var identityProvider = IdentityProvider.Create(
                id: null,
                name: "TestName");
            identityProvider = await new IdentityProviderRepository(_databaseContext).Save(identityProvider);

            var user = User.Create(
                id: null,
                email: "TestEmail",
                name: "TestName",
                lastName: "TestLastName",
                displayName: "TestDisplayName",
                userRole: role,
                identityProvider: identityProvider,
                useGravatar: true);
            user = await new UserRepository(_databaseContext).Save(user);

            var category = Category.Create(
                id: null,
                name: "TestName",
                slug: "TestSlug");
            category = await new CategoryRepository(_databaseContext).Save(category);

            var tag = Tag.Create(
                id: null,
                name: "TestName",
                slug: "TestSlug");
            tag = await new TagRepository(_databaseContext).Save(tag);

            var mediaType = MediaType.Create(
                id: null,
                name: "TestName");
            mediaType = await new MediaTypeRepository(_databaseContext).Save(mediaType);

            var media = Media.Create(
                id: null,
                mediaType: mediaType,
                publishedDate: DateTime.Today,
                filename: "TestName");
            media = await new MediaRepository(_databaseContext).Save(media);

            return Article.Create(
                id: id ?? null,
                title: title ?? "TestTitle",
                author: user,
                category: category,
                tags: new List<Tag> { tag },
                permalink: "TestLinik",
                coverImage: media,
                seoKeyphrase: "TestPhrase",
                content: "TestContent",
                publishedDate: DateTime.Today,
                modifiedDate: DateTime.Today);
        }
    }
}
