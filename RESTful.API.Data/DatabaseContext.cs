using Microsoft.EntityFrameworkCore;
using RESTful.API.Data.Models;
using RESTful.API.Data.Models.Configurations;

namespace RESTful.API.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {            
        }

        #region Models
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        #endregion

        #region ModelOverrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            new DbInitializer(modelBuilder).Seed();
            base.OnModelCreating(modelBuilder);
        }
        #endregion


    }
}
