using AutoMapper;
using FrankPress.DataAccess.Abstractions;
using FrankPress.Domain.Abstractions;
using FrankPress.Domain.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FrankPress.Domain.Test.Services
{
    public class IdentityProviderServiceTest
    {
        private readonly IIdentityProviderService _identityProviderService;
        private readonly Mock<IIdentityProviderRepository> _mockedIdentityProviderRepository;
        private readonly Mock<IMapper> _mockedMapper;

        public IdentityProviderServiceTest()
        {
            _mockedIdentityProviderRepository = new Mock<IIdentityProviderRepository>();
            _mockedMapper = new Mock<IMapper>();
            _identityProviderService = new IdentityProviderService(_mockedIdentityProviderRepository.Object, _mockedMapper.Object);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task GetOrAdd_ReturnsIdentityProvider(DataAccess.DataModels.IdentityProvider? existingIdentityProvider)
        {
            //Arrange
            var dataIdentityProvider = TestDataModels.GetMockedIdentityProvider();
            var domainIdentityProvider = TestDomainModels.GetMockedIdentityProvider();
            _mockedIdentityProviderRepository.Reset();
            _mockedMapper.Reset();
            _mockedIdentityProviderRepository
                .Setup(x => x.GetByName(It.IsAny<string>()))
                .ReturnsAsync(existingIdentityProvider);
            _mockedIdentityProviderRepository
                .Setup(x => x.Save(It.IsAny<DataAccess.DataModels.IdentityProvider>()))
                .ReturnsAsync(dataIdentityProvider);
            _mockedMapper
                .Setup(x => x.Map<Domain.DomainModels.IdentityProvider>(It.IsAny<DataAccess.DataModels.IdentityProvider>()))
                .Returns(domainIdentityProvider);

            //Act
            var result = await _identityProviderService.GetOrAdd(dataIdentityProvider.Name);

            //Assert
            _mockedIdentityProviderRepository
                .Verify(x => x.GetByName(dataIdentityProvider.Name), Times.Once());
            if (existingIdentityProvider == null)
            {
                _mockedIdentityProviderRepository
                    .Verify(x => x.Save(It.Is<DataAccess.DataModels.IdentityProvider>(t => t.Name == dataIdentityProvider.Name && t.Id == null)), Times.Once());
            }
            _mockedMapper
                .Verify(x => x.Map<Domain.DomainModels.IdentityProvider>(It.Is<DataAccess.DataModels.IdentityProvider>(t => t.Id == domainIdentityProvider.Id)),
                Times.Once);
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Data =>
            new object[][]
            {
                new object[] { null! },
                new object[] { TestDataModels.GetMockedIdentityProvider() }
            };
    }
}
