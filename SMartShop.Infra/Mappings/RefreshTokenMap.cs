using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Mappings
{
    public class RefreshTokenMap : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            #region Properties

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Token)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            #endregion

            #region Relationships

            builder.HasOne(x => x.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
        }
    }
}
