using DiplomaProject.Backend.Common.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.Backend.Common.DataBaseConfigurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("services");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.Shop);

            builder.HasOne(t => t.Promotion);

            builder.HasMany(t => t.Orders);
        }
    }
}
