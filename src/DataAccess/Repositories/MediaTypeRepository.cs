using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;

namespace FrankPress.DataAccess.Repositories
{
    public class MediaTypeRepository : BaseRepository<MediaType>, IMediaTypeRepository
    {
        public MediaTypeRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
