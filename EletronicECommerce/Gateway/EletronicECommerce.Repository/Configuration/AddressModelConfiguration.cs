using EletronicECommerce.Repository.Models.SubModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class AddressModelConfiguration : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder)
        {
            builder
                .ToTable("Address");

            builder
                .HasKey(x => x.Id)
                .HasName("Pk_Address");

            builder
                .Property(x => x.AddressType)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder
                .Property(x => x.City)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(x => x.Country)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.Neighborhood)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.Customer)
                .HasColumnType("char(36)")
                .IsRequired();

            builder
                .Property(x => x.Number)
                .HasColumnType("varchar(10)")
                .HasDefaultValue("S/N");

            builder
                .Property(x => x.Street)
                .HasColumnType("varchar(500)")
                .IsRequired();
        
            builder
                .Property(x => x.State)
                .HasColumnType("varchar(2)")
                .IsRequired();
        }
    }
}