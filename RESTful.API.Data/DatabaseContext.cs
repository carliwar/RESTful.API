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

        #region Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            new DbInitializer(modelBuilder).Seed();
        }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        {
            AddCreatedByOrUpdatedBy();
            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region Private Methods

        public void AddCreatedByOrUpdatedBy()
        {
            foreach (var changedEntity in ChangeTracker.Entries())
            {
                if (changedEntity.Entity is BaseDataModel entity)
                {
                    switch (changedEntity.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = DateTime.UtcNow;
                            entity.UpdatedDate = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:          
                            entity.UpdatedDate = DateTime.UtcNow;
                            break;
                    }
                }
            }
        }
        #endregion


    }
}
