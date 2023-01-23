using DiplomaProject.Backend.Common.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiplomaProject.Backend.Common.DataBaseConfigurations
{
    public class ShopUserConfiguration : IEntityTypeConfiguration<ShopUser>
    {
        public void Configure(EntityTypeBuilder<ShopUser> builder)
        {
            builder.ToTable("shop_user");

            builder.HasKey(t => new { t.ShopId, t.UserId });

            builder.HasOne(t => t.User);
            builder.HasOne(t => t.Shop);
        }
    }
}
