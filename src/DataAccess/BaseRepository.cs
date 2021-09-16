using FrankPress.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrankPress.DataAccess
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseDataModel
    {
        internal readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public virtual async Task Delete(int id)
        {
            var result = await _databaseContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
            {
                return;
            }

            _databaseContext.Remove(result);

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T?> Get(int id)
        {
            return await _databaseContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _databaseContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> Save(T entity)
        {
            var result = await _databaseContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entity.Id);

            try
            {
                if (result == null)
                {
                    _databaseContext.Add(entity);
                }
                else
                {
                    _databaseContext.Entry(result).State = EntityState.Detached;
                    _databaseContext.Update(entity);
                }

                await _databaseContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

            return entity;
        }
    }
}
