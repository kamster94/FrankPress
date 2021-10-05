using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace FrankPress.DataAccess.Test.Repositories
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

        [Fact]
        public async Task GetByName_ShouldReturnIdentityProvider()
        {
            //Arrange
            var identityProvider = GetIdentityProvider();
            identityProvider = await Repository!.Save(identityProvider);

            //Act
            var result = await ((IdentityProviderRepository)Repository!).GetByName(identityProvider.Name);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(identityProvider, result);
        }

        protected IdentityProvider GetIdentityProvider(int? id = null, string? name = null)
        {
            return IdentityProvider.Create(
                id: id ?? null,
                name: name ?? "TestName");
        }
    }
}
