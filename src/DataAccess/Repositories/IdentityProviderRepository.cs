using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Repositories
{
    public class IdentityProviderRepository : BaseRepository<IdentityProvider>, IIdentityProviderRepository
    {
        public IdentityProviderRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IdentityProvider?> GetByName(string name)
        {
            return await _databaseContext.IdentityProviders.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
