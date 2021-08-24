using EletronicECommerce.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class ProductModelConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder
                .ToTable("Product");

            builder
                .HasKey(x  => x.Id)
                .HasName("Pk_Product");

            builder
                .Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(x => x.Code)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder
                .Property(x => x.PurchasePrice)
                .HasColumnType("decimal(15,2)")
                .IsRequired();
            
            builder
                .Property(x => x.SalePrice)
                .HasColumnType("decimal(15,2)")
                .IsRequired();

            builder
                .Property(x => x.Quantity)
                .HasColumnType("int");            

            builder
                .Property(x => x.Category)
                .HasColumnType("char(36)")
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}