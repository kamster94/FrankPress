using FrankPress.DataAccess.DataModels;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Abstractions
{
    public interface IIdentityProviderRepository : IRepository<IdentityProvider>
    {
        Task<IdentityProvider?> GetByName(string name);
    }
}
