using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Mappings
{
    public class PhoneNumberMap : IEntityTypeConfiguration<PhoneNumber>
    {
        public void Configure(EntityTypeBuilder<PhoneNumber> builder)
        {
            #region Properties

            builder.Property(x => x.Phone)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            #endregion

            #region Entity Properties (standard)

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.CreatedBy)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("datetime");

            builder.Property(x => x.UpdatedBy)
                .HasColumnType("int");

            builder.Property(x => x.DeletedAt)
                .HasColumnType("datetime");

            builder.Property(x => x.DeletedBy)
                .HasColumnType("int");

            builder.Property(x => x.Deleted)
                .HasColumnType("bit");

            builder.Property(x => x.Active)
                .HasColumnType("bit");

            #endregion
        }
    }
}
