using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Test.Repositories
{
    public class CategoryRepositoryTest : BaseRepositoryTest<Category>
    {
        public CategoryRepositoryTest()
        {
            Repository = new CategoryRepository(_databaseContext);
            GetEntity = GetCategory;
        }

        [Fact]
        public async Task Get_ShouldReturnCategory() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateCategory() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteCategory() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnCategories() => await GetAll_Test();

        protected Category GetCategory(int? id = null, string? name = null)
        {
            return Category.Create(
                id: id ?? null,
                name: name ?? "TestName",
                slug: "TestSlug");
        }
    }
}
