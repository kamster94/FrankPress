using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Enums;
using FrankPress.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Test.Repositories
{
    public class MediaRepositoryTest : BaseRepositoryTest<Media>
    {
        public MediaRepositoryTest()
        {
            Repository = new MediaRepository(_databaseContext);
            GetEntityAsync = GetMedia;
        }

        [Fact]
        public async Task Get_ShouldReturnMedia() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateMedia() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteMedia() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnMedia() => await GetAll_Test();

        [Fact]
        public async Task GetByMediaType_ShouldReturnMedia()
        {
            //Arrange
            var media = await GetMedia();
            media = await Repository!.Save(media);

            //Act
            var results = await ((MediaRepository)Repository!).GetByMediaType((int)media.MediaType.Id!);

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(media, results);
        }

        [Theory, MemberData(nameof(TestDates))]
        public async Task GetByPublishedDate_ShouldReturnMedia(DateTime date, ComparisonOperator comparisonOperator)
        {
            //Arrange
            var media = await GetMedia();
            media = await Repository!.Save(media);

            //Act
            var results = await ((MediaRepository)Repository!).GetByPublishedDate(date, comparisonOperator);

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(media, results);
        }

        private static IEnumerable<object[]> TestDates()
        {
            yield return new object[] { DateTime.Today.AddDays(1), ComparisonOperator.LessThan };
            yield return new object[] { DateTime.Today.AddDays(-1), ComparisonOperator.GreaterThan };
            yield return new object[] { DateTime.Today, ComparisonOperator.Equal };
        }

        protected async Task<Media> GetMedia(int? id = null, string? filename = null)
        {
            var mediaTypeRepository = new MediaTypeRepository(_databaseContext);
            var mediaType = MediaType.Create(
                id: null,
                name: "TestName");
            mediaType = await mediaTypeRepository.Save(mediaType);
            return Media.Create(
                id: id ?? null,
                mediaType: mediaType,
                publishedDate: DateTime.Today,
                filename: filename ?? "TestName");
        }
    }
}
