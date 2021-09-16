using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace DataAccess.Test.Repositories
{
    public class IdentityProviderRepositoryTest : BaseRepositoryTest<IdentityProvider>
    {
        public IdentityProviderRepositoryTest()
        {
            Repository = new IdentityProviderRepository(_databaseContext);
            GetEntity = GetIdentityProvider;
        }

        [Fact]
        public async Task Get_ShouldReturnIdentityProvider() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateIdentityProvider() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteIdentityProvider() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnIdentityProviders() => await GetAll_Test();

        protected IdentityProvider GetIdentityProvider(int? id = null, string? name = null)
        {
            return IdentityProvider.Create(
                id: id ?? null,
                name: name ?? "TestName");
        }
    }
}
