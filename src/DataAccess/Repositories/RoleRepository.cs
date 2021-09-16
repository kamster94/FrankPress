using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;

namespace FrankPress.DataAccess.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
