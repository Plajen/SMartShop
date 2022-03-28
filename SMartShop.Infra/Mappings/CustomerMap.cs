using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            #region Properties

            builder.Property(x => x.FirstName)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(x => x.MiddleName)
                .HasColumnType("varchar(MAX)");

            builder.Property(x => x.LastName)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .HasColumnType("datetime")
                .IsRequired();

            #endregion

            #region Relationships

            builder.HasOne(x => x.Address)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Phones)
                .WithOne()
                .HasForeignKey(y => y.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Email)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

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
