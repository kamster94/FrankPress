using FrankPress.DataAccess.Abstractions;
using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Repositories
{
    public class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        public MediaRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Media>?> GetByMediaType(int mediaTypeId)
        {
            if (_databaseContext.Media == null)
            {
                return null;
            }

            return await _databaseContext.Media
                .Where(x => x.MediaType.Id == mediaTypeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Media>?> GetByPublishedDate(DateTime date, ComparisonOperator comparisonOperator)
        {
            if (_databaseContext.Media == null)
            {
                return null;
            }

            var results = new List<Media>();
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return await _databaseContext.Media.Where(x => x.PublishedDate == date).ToListAsync();
                case ComparisonOperator.GreaterThan:
                    return await _databaseContext.Media.Where(x => x.PublishedDate > date).ToListAsync();
                case ComparisonOperator.LessThan:
                    return await _databaseContext.Media.Where(x => x.PublishedDate < date).ToListAsync();
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonOperator));
            }
        }
    }
}
