using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;

namespace FrankPress.DataAccess.Repositories
{
    public class IdentityProviderRepository : BaseRepository<IdentityProvider>, IIdentityProviderRepository
    {
        public IdentityProviderRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
