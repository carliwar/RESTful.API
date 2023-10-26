using Microsoft.EntityFrameworkCore;
using RESTful.API.Data.Models;

namespace RESTful.API.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            // add a record for _modelBuilder.Entity<UserType>
            _modelBuilder.Entity<UserType>(
                ut =>
                {
                    ut.HasData(new UserType
                    {
                        Id = 1,
                        Name = "Admin"                        
                    });
                    ut.HasData(new UserType
                    {
                        Id = 2,
                        Name = "User"
                    });
                }
            );

            _modelBuilder.Entity<User>(
                u =>
                {
                    u.HasData(new User
                    {
                        Id = 1,
                        FirstName = "Admin",
                        LastName = "Admin",
                        DateOfBirth = new DateTime(1991,2,1),
                        Identification = "1111111111",
                        TypeId = 1
                    });
                }
            );

            _modelBuilder.Entity<User>(
                u =>
                {
                    u.HasData(new User
                    {
                        Id = 2,
                        FirstName = "User",
                        LastName = "Test",
                        DateOfBirth = new DateTime(1992, 5, 5),
                        Identification = "2222222222",
                        TypeId = 2
                    });
                }
            );

        }
    }
}
