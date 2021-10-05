using AutoMapper;
using Xunit;

namespace FrankPress.Domain.Test
{
    public class ModelMappingTest
    {
        [Fact]
        public void AutoMapper_Configuration_IsValid()
        {
            var config = new MapperConfiguration(x => x.AddProfile<ModelMappingProfile>());
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void AutoMapper_Returns_Role_DomainModel()
        {
            //Arrange
            var config = new MapperConfiguration(x => x.AddProfile<ModelMappingProfile>());
            var mapper = config.CreateMapper();
            var model = TestDataModels.GetMockedRole();

            //Act
            var result = mapper.Map<Domain.DomainModels.Role>(model);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.DomainModels.Role>(result);
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
        }

        [Fact]
        public void AutoMapper_Returns_IdentityProvider_DomainModel()
        {
            //Arrange
            var config = new MapperConfiguration(x => x.AddProfile<ModelMappingProfile>());
            var mapper = config.CreateMapper();
            var model = TestDataModels.GetMockedIdentityProvider();

            //Act
            var result = mapper.Map<Domain.DomainModels.IdentityProvider>(model);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.DomainModels.IdentityProvider>(result);
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Name, result.Name);
        }

        [Fact]
        public void AutoMapper_Returns_User_DomainModel()
        {
            //Arrange
            var config = new MapperConfiguration(x => x.AddProfile<ModelMappingProfile>());
            var mapper = config.CreateMapper();
            var model = TestDataModels.GetMockedUser();

            //Act
            var result = mapper.Map<Domain.DomainModels.User>(model);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<Domain.DomainModels.User>(result);
            Assert.Equal(model.Id, result.Id);
            Assert.Equal(model.Email, result.Email);
            Assert.Equal(model.Name, result.Name);
            Assert.Equal(model.LastName, result.LastName);
            Assert.Equal(model.DisplayName, result.DisplayName);
            Assert.Equal(model.UserRole.Id, result.UserRole.Id);
            Assert.Equal(model.UserRole.Name, result.UserRole.Name);
            Assert.Equal(model.IdentityProvider.Id, result.IdentityProvider.Id);
            Assert.Equal(model.IdentityProvider.Name, result.IdentityProvider.Name);
            Assert.Equal(model.UseGravatar, result.UseGravatar);
        }
    }
}
