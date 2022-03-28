using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            #region Properties

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(x => x.NormalizedName)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            #endregion
        }
    }
}
