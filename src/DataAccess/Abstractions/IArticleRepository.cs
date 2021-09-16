using FrankPress.DataAccess.DataModels;
using FrankPress.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrankPress.DataAccess.Abstractions
{
    public interface IArticleRepository : IRepository<Article>
    {
        public Task<IEnumerable<Article>?> GetByAuthor(int authorId);

        public Task<IEnumerable<Article>?> GetByCategory(int categoryId);

        public Task<IEnumerable<Article>?> GetByTags(IEnumerable<int> tagIds);

        public Task<IEnumerable<Article>?> GetByPublishedDate(DateTime date, ComparisonOperator comparisonOperator);

        public Task<IEnumerable<Article>?> GetByModifiedDate(DateTime date, ComparisonOperator comparisonOperator);
    }
}
