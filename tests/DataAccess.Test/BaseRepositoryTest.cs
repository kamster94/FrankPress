using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FrankPress.DataAccess.Test
{
    public class BaseRepositoryTest<T> : IDisposable where T : BaseDataModel
    {
        protected BaseRepository<T>? Repository { get; set; }
        protected Func<int?, string?, T> GetEntity { get; set; } = null!;
        protected Func<int?, string?, Task<T>> GetEntityAsync { get; set; } = null!;
        protected IConfiguration Configuration;
        protected readonly DatabaseContext _databaseContext;
        private readonly IDbContextTransaction _transaction;

        public BaseRepositoryTest()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<BaseRepositoryTest<T>>();
            Configuration = builder.Build();

            _databaseContext = new DatabaseContext(
                new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(Configuration.GetConnectionString("Default"))
                .Options);

            _transaction = _databaseContext.Database.BeginTransaction();
        }

        public async Task Get_Test()
        {
            //Arrange
            T entity;
            if (GetEntity != null)
            {
                entity = GetEntity(null, null);
            }
            else
            {
                entity = await GetEntityAsync(null, null);
            }
            entity = await Repository!.Save(entity);

            //Act
            var result = await Repository.Get((int)entity.Id!);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(entity, result);
        }

        public async Task Save_Test()
        {
            //Arrange
            T entity;
            if (GetEntity != null)
            {
                entity = GetEntity(null, null);
            }
            else
            {
                entity = await GetEntityAsync(null, null);
            }
            entity = await Repository!.Save(entity);
            T toUpdate;
            if (GetEntity != null)
            {
                toUpdate = GetEntity(entity.Id, "Updated Name");
            }
            else
            {
                toUpdate = await GetEntityAsync(entity.Id, "Updated Name");
            }

            //Act
            toUpdate = await Repository.Save(toUpdate);

            //Assert
            var result = await Repository.Get((int)entity.Id!);
            Assert.NotNull(result);
            Assert.Equal(toUpdate, result);
        }

        public async Task Delete_Test()
        {
            //Arrange
            T entity;
            if (GetEntity != null)
            {
                entity = GetEntity(null, null);
            }
            else
            {
                entity = await GetEntityAsync(null, null);
            }
            entity = await Repository!.Save(entity);

            //Act
            await Repository.Delete((int)entity.Id!);

            //Assert
            var result = await Repository.Get((int)entity.Id!);
            Assert.Null(result);
        }

        public async Task GetAll_Test()
        {
            //Arrange
            T entity;
            if (GetEntity != null)
            {
                entity = GetEntity(null, null);
            }
            else
            {
                entity = await GetEntityAsync(null, null);
            }
            entity = await Repository!.Save(entity);

            //Act
            var results = await Repository.GetAll();

            //Assert
            Assert.NotEmpty(results);
            Assert.Contains(entity, results);
        }

        public void Dispose() => _transaction.Rollback();
    }
}
