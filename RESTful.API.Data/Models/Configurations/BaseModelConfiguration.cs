using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RESTful.API.Data.Models.Configurations
{
    public class BaseModelConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseDataModel
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedBy).IsRequired().HasDefaultValue(-1);
            builder.Property(x => x.UpdatedBy).IsRequired().HasDefaultValue(-1);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.UpdatedDate).IsRequired().HasDefaultValue(DateTime.UtcNow);
        }
    }
}
