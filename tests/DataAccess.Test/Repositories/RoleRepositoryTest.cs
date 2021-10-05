using FrankPress.DataAccess.Repositories;
using FrankPress.DataAccess.DataModels;
using Xunit;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Test.Repositories
{
    public class RoleRepositoryTest : BaseRepositoryTest<Role>
    {
        public RoleRepositoryTest()
        {
            Repository = new RoleRepository(_databaseContext);
            GetEntity = GetRole;
        }

        [Fact]
        public async Task Get_ShouldReturnMediaType() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateMediaType() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteMediaType() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnMediaTypes() => await GetAll_Test();

        protected Role GetRole(int? id = null, string? name = null)
        {
            return Role.Create(
                id: id ?? null,
                name: name ?? "TestName");
        }
    }
}
