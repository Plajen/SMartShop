using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Mappings
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            #region Properties

            builder.Property(x => x.Bytes)
                .HasColumnType("varbinary(MAX)")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(x => x.FileExtension)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Size)
                .HasColumnType("decimal(38,2")
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
