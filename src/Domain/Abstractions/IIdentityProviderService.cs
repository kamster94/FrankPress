using FrankPress.Domain.DomainModels;

namespace FrankPress.Domain.Abstractions
{
    public interface IIdentityProviderService
    {
        Task<IdentityProvider> GetOrAdd(string name);
    }
}
