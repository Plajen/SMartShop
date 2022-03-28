using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMartShop.Domain.Models;

namespace SMartShop.Infra.Mappings
{
    public class StateMap : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            #region Properties

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(x => x.Abbreviation)
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();

            #endregion
        }
    }
}
