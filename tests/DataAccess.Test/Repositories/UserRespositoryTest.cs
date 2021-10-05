using FrankPress.DataAccess.Repositories;
using FrankPress.DataAccess.DataModels;
using Xunit;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Test.Repositories
{
    public class UserRespositoryTest : BaseRepositoryTest<User>
    {
        public UserRespositoryTest()
        {
            Repository = new UserRepository(_databaseContext);
            GetEntityAsync = GetUser;
        }

        [Fact]
        public async Task Get_ShouldReturnMediaType() => await Get_Test();

        [Fact]
        public async Task Save_ShouldUpdateMediaType() => await Save_Test();

        [Fact]
        public async Task Delete_ShouldDeleteMediaType() => await Delete_Test();

        [Fact]
        public async Task GetAll_ShouldReturnMediaTypes() => await GetAll_Test();

        [Fact]
        public async Task GetByRole_ShouldReturnRole()
        {
            //Arrange
            var user = await GetUser();
            user = await Repository!.Save(user);

            //Act
            var results = await ((UserRepository)Repository!).GetByRole((int)user.UserRole.Id!);

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(user, results);
        }

        [Fact]
        public async Task GetByIdentityProviderAndEmail_ShouldReturnRole()
        {
            //Arrange
            var user = await GetUser();
            user = await Repository!.Save(user);

            //Act
            var result = await ((UserRepository)Repository!).GetByIdentityProviderAndEmail((int)user.IdentityProvider.Id!, user.Email);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        protected async Task<User> GetUser(int? id = null, string? name = null)
        {
            var _roleRepository = new RoleRepository(_databaseContext);
            var _identityProviderRepositoryy = new IdentityProviderRepository(_databaseContext);
            var role = Role.Create(
                id: null,
                name: "TestName");
            role = await _roleRepository.Save(role);

            var identityProvider = IdentityProvider.Create(
                id: null,
                name: "TestName");
            identityProvider = await _identityProviderRepositoryy.Save(identityProvider);

            return User.Create(
                id: id ?? null,
                email: "TestEmail",
                name: name ?? "TestName",
                lastName: "TestLastName",
                displayName: "TestDisplayName",
                userRole: role,
                identityProvider: identityProvider,
                useGravatar: true);
        }
    }
}
