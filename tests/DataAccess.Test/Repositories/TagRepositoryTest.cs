using FrankPress.DataAccess;
using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Test.Repositories
{
    public class TagRepositoryTest : BaseRepositoryTest<Tag>
    {
        public TagRepositoryTest()
        {
            Repository = new TagRepository(_databaseContext);
            GetEntity = GetTag;
        }

        [Fact]
        public async Task Get_ShouldReturnTag() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateTag() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteTag() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnTags() => await GetAll_Test();

        protected Tag GetTag(int? id = null, string? name = null)
        {
            return Tag.Create(
                id: id ?? null,
                name: name ?? "TestName",
                slug: "TestSlug");
        }
    }
}