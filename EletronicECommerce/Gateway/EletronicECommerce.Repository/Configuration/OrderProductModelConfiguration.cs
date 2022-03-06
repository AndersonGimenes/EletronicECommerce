using EletronicECommerce.Repository.Models.SubModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class OrderProductModelConfiguration : IEntityTypeConfiguration<OrderProductModel>
    {
        public void Configure(EntityTypeBuilder<OrderProductModel> builder)
        {
            builder
                .ToTable("OrderProduct");

            builder
                .HasKey(x => x.Id)
                .HasName("Pk_OrderProduct");

            builder
                .Property(x => x.Quantity)
                .HasColumnType("int")
                .IsRequired();

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Orders)
                .HasConstraintName("Fk_Product_Order")
                .HasForeignKey("ProductId");

            builder
                .HasOne(x => x.Order)
                .WithMany(x => x.Products)
                .HasConstraintName("Fk_Order_Product")
                .HasForeignKey("OrderId");
        }
    }
}