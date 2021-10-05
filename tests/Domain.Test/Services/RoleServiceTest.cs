using AutoMapper;
using FrankPress.DataAccess.Abstractions;
using FrankPress.Domain.Abstractions;
using FrankPress.Domain.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace FrankPress.Domain.Test.Services
{
    public class RoleServiceTest
    {
        private readonly IRoleService _roleService;
        private readonly Mock<IRoleRepository> _mockedRoleRepository;
        private readonly Mock<IMapper> _mockedMapper;

        public RoleServiceTest()
        {
            _mockedRoleRepository = new Mock<IRoleRepository>();
            _mockedMapper = new Mock<IMapper>();
            _roleService = new RoleService(_mockedRoleRepository.Object, _mockedMapper.Object);
        }

        [Fact]
        public async Task GetRole_ReturnsRole()
        {
            //Arrange
            var dataRole = TestDataModels.GetMockedRole();
            var domainRole = TestDomainModels.GetMockedRole();
            _mockedRoleRepository.Reset();
            _mockedMapper.Reset();
            _mockedRoleRepository
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(dataRole);
            _mockedMapper
                .Setup(x => x.Map<Domain.DomainModels.Role>(It.IsAny<DataAccess.DataModels.Role>()))
                .Returns(domainRole);

            //Act
            var result = await _roleService.GetRole(dataRole.Id!.Value);

            //Assert
            _mockedRoleRepository.Verify(x => x.Get(dataRole.Id!.Value), Times.Once);
            _mockedMapper
                .Verify(x => x.Map<Domain.DomainModels.Role>(It.Is<DataAccess.DataModels.Role>(t => t.Id == domainRole.Id)),
                Times.Once);
            Assert.NotNull(result);
        }
    }
}
