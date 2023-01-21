using DiplomaProject.Backend.Common.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.Backend.Common.DataBaseConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("clients");

            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.User);

            builder.HasMany(t => t.Orders);
        }
    }
}
