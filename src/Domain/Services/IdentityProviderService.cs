using AutoMapper;
using FrankPress.DataAccess.Abstractions;
using FrankPress.Domain.Abstractions;
using FrankPress.Domain.DomainModels;

namespace FrankPress.Domain.Services
{
    public class IdentityProviderService : IIdentityProviderService
    {
        private readonly IIdentityProviderRepository _identityProviderRepository;
        private readonly IMapper _mapper;

        public IdentityProviderService(IIdentityProviderRepository identityProviderRepository, IMapper mapper)
        {
            _identityProviderRepository = identityProviderRepository;
            _mapper = mapper;
        }

        public async Task<IdentityProvider> GetOrAdd(string name)
        {
            var result = await _identityProviderRepository.GetByName(name);

            if (result == null)
            {
                result = DataAccess.DataModels.IdentityProvider.Create(null, name);
                result = await _identityProviderRepository.Save(result);
            }

            return _mapper.Map<IdentityProvider>(result);
        }
    }
}
