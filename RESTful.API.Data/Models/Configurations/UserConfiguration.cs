using Microsoft.EntityFrameworkCore;

namespace RESTful.API.Data.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {        
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {            
            
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Identification).IsRequired();
            builder.Property(x => x.DateOfBirth).IsRequired(false);

            builder.HasOne(x => x.Type).WithMany(x => x.Users).HasForeignKey(x => x.TypeId);
        }
    }
}
