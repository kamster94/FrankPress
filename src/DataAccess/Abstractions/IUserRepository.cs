using FrankPress.DataAccess.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<IEnumerable<User>?> GetByRole(int roleId);

        public Task<User?> GetByIdentityProviderAndEmail(int identityProviderId, string email);
    }
}
