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
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<IEnumerable<Article>?> GetByAuthor(int authorId)
        {
            if (_databaseContext.Articles == null)
            {
                return null;
            }

            return await _databaseContext.Articles
                .Where(x => x.Author.Id == authorId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>?> GetByCategory(int categoryId)
        {
            if (_databaseContext.Articles == null)
            {
                return null;
            }

            return await _databaseContext.Articles
                .Where(x => x.Category.Id == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Article>?> GetByTags(IEnumerable<int> tagIds)
        {
            if (_databaseContext.Articles == null)
            {
                return null;
            }

            var results = await GetAll();

            return results
                .Where(x => x.Tags!.Any(t => tagIds.Any(n => n == t.Id)))
                .ToList();
        }

        public async Task<IEnumerable<Article>?> GetByModifiedDate(DateTime date, ComparisonOperator comparisonOperator)
        {
            if (_databaseContext.Articles == null)
            {
                return null;
            }

            var results = new List<Article>();
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return await _databaseContext.Articles.Where(x => x.ModifiedDate == date).ToListAsync();
                case ComparisonOperator.GreaterThan:
                    return await _databaseContext.Articles.Where(x => x.ModifiedDate > date).ToListAsync();
                case ComparisonOperator.LessThan:
                    return await _databaseContext.Articles.Where(x => x.ModifiedDate < date).ToListAsync();
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonOperator));
            }
        }

        public async Task<IEnumerable<Article>?> GetByPublishedDate(DateTime date, ComparisonOperator comparisonOperator)
        {
            if (_databaseContext.Articles == null)
            {
                return null;
            }

            var results = new List<Article>();
            switch (comparisonOperator)
            {
                case ComparisonOperator.Equal:
                    return await _databaseContext.Articles.Where(x => x.PublishedDate == date).ToListAsync();
                case ComparisonOperator.GreaterThan:
                    return await _databaseContext.Articles.Where(x => x.PublishedDate > date).ToListAsync();
                case ComparisonOperator.LessThan:
                    return await _databaseContext.Articles.Where(x => x.PublishedDate < date).ToListAsync();
                default:
                    throw new ArgumentOutOfRangeException(nameof(comparisonOperator));
            }
        }
    }
}
