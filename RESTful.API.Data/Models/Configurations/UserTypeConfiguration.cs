using Microsoft.EntityFrameworkCore;

namespace RESTful.API.Data.Models.Configurations
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
    {        
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserType> builder)
        {            
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
