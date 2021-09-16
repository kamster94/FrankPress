using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Abstractions
{
    public interface IRepository<T> where T : BaseDataModel
    {
        Task<T?> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task Delete(int id);

        Task<T> Save(T entity);
    }
}
