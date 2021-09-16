using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Test.Repositories
{
    public class MediaTypeRepositoryTest : BaseRepositoryTest<MediaType>
    {
        public MediaTypeRepositoryTest()
        {
            Repository = new MediaTypeRepository(_databaseContext);
            GetEntity = GetMediaType;
        }

        [Fact]
        public async Task Get_ShouldReturnMediaType() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateMediaType() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteMediaType() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnMediaTypes() => await GetAll_Test();

        protected MediaType GetMediaType(int? id = null, string? name = null)
        {
            return MediaType.Create(
                id: id ?? null,
                name: name ?? "TestName");
        }
    }
}
