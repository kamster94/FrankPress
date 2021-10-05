using FrankPress.Domain.DomainModels;
using FrankPress.Domain.Requests;

namespace FrankPress.Domain.Abstractions
{
    public interface IUserService
    {
        Task<int?> GetCurrentUserId(int identityProvider, string email);

        Task<User> GetCurrentUser(int id);

        Task<User> AddUser(UserCreateRequest request);
    }
}
