using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;

namespace FrankPress.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
