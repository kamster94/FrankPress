using FrankPress.Domain.DomainModels;

namespace FrankPress.Domain.Abstractions
{
    public interface IRoleService
    {
        Task<Role?> GetRole(int id);
    }
}
