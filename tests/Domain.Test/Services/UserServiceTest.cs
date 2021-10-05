using AutoMapper;
using FrankPress.DataAccess.Abstractions;
using FrankPress.Domain.Abstractions;
using FrankPress.Domain.Requests;
using FrankPress.Domain.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace FrankPress.Domain.Test.Services
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;
        private readonly Mock<IUserRepository> _mockedUserRepository;
        private readonly Mock<IMapper> _mockedMapper;

        public UserServiceTest()
        {
            _mockedUserRepository = new Mock<IUserRepository>();
            _mockedMapper = new Mock<IMapper>();
            _userService = new UserService(_mockedUserRepository.Object, _mockedMapper.Object);
        }

        [Fact]
        public async Task GetCurrentUserId_ReturnsId()
        {
            //Arrange
            var user = TestDataModels.GetMockedUser();
            _mockedUserRepository.Reset();
            _mockedUserRepository
                .Setup(x => x.GetByIdentityProviderAndEmail(It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync(user);

            //Act
            var id = await _userService.GetCurrentUserId(user.IdentityProvider.Id!.Value, user.Email);

            //Assert
            _mockedUserRepository.Verify(x => x.GetByIdentityProviderAndEmail(user.IdentityProvider.Id!.Value, user.Email), Times.Once);
            Assert.NotNull(id);
        }

        [Fact]
        public async Task GetCurrentUser_ReturnsUser()
        {
            //Arrange
            var dataUser = TestDataModels.GetMockedUser();
            var domainUser = TestDomainModels.GetMockedUser();
            _mockedUserRepository.Reset();
            _mockedMapper.Reset();
            _mockedUserRepository
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(dataUser);
            _mockedMapper
                .Setup(x => x.Map<Domain.DomainModels.User>(It.IsAny<DataAccess.DataModels.User>()))
                .Returns(domainUser);

            //Act
            var result = await _userService.GetCurrentUser(dataUser.Id!.Value);

            //Assert
            _mockedUserRepository.Verify(x => x.Get(dataUser.Id!.Value), Times.Once);
            _mockedMapper.Verify(x => x.Map<Domain.DomainModels.User>(dataUser), Times.Once);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddUser_ReturnsUser()
        {
            //Arrange
            var dataUser = TestDataModels.GetMockedUser();
            var domainUser = TestDomainModels.GetMockedUser();
            _mockedUserRepository.Reset();
            _mockedMapper.Reset();
            _mockedUserRepository
                .Setup(x => x.Save(It.IsAny<DataAccess.DataModels.User>()))
                .ReturnsAsync(dataUser);
            _mockedMapper
                .Setup(x => x.Map<Domain.DomainModels.User>(It.IsAny<DataAccess.DataModels.User>()))
                .Returns(domainUser);
            var createUserRequest = new UserCreateRequest
            {
                Name = domainUser.Name,
                LastName = domainUser.LastName,
                Email = domainUser.Email,
                IdentityProvider = domainUser.IdentityProvider,
                UserRole = domainUser.UserRole
            };

            //Act
            var result = await _userService.AddUser(createUserRequest);

            //Assert
            _mockedUserRepository
                .Verify(x => x.Save(It.Is<DataAccess.DataModels.User>(t => t.Name == domainUser.Name && t.Id == null)), Times.Once);
            _mockedMapper.Verify(x => x.Map<Domain.DomainModels.User>(dataUser), Times.Once);
            Assert.NotNull(result);
        }
    }
}
