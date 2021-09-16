using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;

namespace FrankPress.DataAccess.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
