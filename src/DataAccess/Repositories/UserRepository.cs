using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IEnumerable<User>?> GetByIdentityProvider(int identityProviderId)
        {
            if (_databaseContext.Users == null)
            {
                return null;
            }

            return await _databaseContext.Users
                .Where(x => x.IdentityProvider.Id == identityProviderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>?> GetByRole(int roleId)
        {
            if (_databaseContext.Users == null)
            {
                return null;
            }

            return await _databaseContext.Users
                .Where(x => x.UserRole.Id == roleId)
                .ToListAsync();
        }
    }
}
