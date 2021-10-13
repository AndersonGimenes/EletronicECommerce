using EletronicECommerce.Repository.Models.SubModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class StockModelConfiguration : IEntityTypeConfiguration<StockModel>
    {
        public void Configure(EntityTypeBuilder<StockModel> builder)
        {
            builder
                .ToTable("ProductStock");

            builder
                .HasKey(x => x.Id)
                .HasName("Pk_Stock");

            builder
                .Property(x => x.Quantity)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.PurchasePrice)
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            builder
                .Property(x => x.Product)
                .HasColumnType("char(36)")
                .IsRequired();
        }
    }
}