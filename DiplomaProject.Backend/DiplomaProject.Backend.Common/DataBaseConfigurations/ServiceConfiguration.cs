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

            builder.HasMany(t => t.Promotions);

            builder.HasMany(t => t.Orders);
        }
    }
}
