using FrankPress.DataAccess.DataModels;
using Microsoft.EntityFrameworkCore;

namespace FrankPress.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Role>? Roles { get; private set; }

        public DbSet<User>? Users {  get; private set; }

        public DbSet<IdentityProvider>? IdentityProviders {  get; private set; }

        public DbSet<Category>? Categories {  get; private set; }

        public DbSet<Tag>? Tags {  get; private set; }

        public DbSet<MediaType>? MediaTypes {  get; private set; }

        public DbSet<Media>? Media {  get; private set; }

        public DbSet<Article>? Articles {  get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable(nameof(Role));
            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<IdentityProvider>().ToTable(nameof(IdentityProvider));
            modelBuilder.Entity<Category>().ToTable(nameof(Category));
            modelBuilder.Entity<Tag>().ToTable(nameof(Tag));
            modelBuilder.Entity<MediaType>().ToTable(nameof(MediaType));
            modelBuilder.Entity<Media>().ToTable(nameof(Media));
            modelBuilder.Entity<Article>().ToTable(nameof(Article));
        }
    }
}
