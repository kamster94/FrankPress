using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Abstractions
{
    public interface IMediaRepository : IRepository<Media>
    {
        public Task<IEnumerable<Media>?> GetByMediaType(int mediaTypeId);

        public Task<IEnumerable<Media>?> GetByPublishedDate(DateTime date, ComparisonOperator comparisonOperator);
    }
}
