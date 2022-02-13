using EletronicECommerce.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class OrderModelConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder
                .ToTable("Order");

            builder
                .HasKey(x  => x.Id)
                .HasName("Pk_Order");

            builder
                .Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .Property(x => x.User)
                .HasColumnType("char(36)")
                .IsRequired();

            builder
                .Property(x => x.ProductId)
                .HasColumnType("char(36)")
                .IsRequired();

            builder
                .Property(x => x.TypePayment)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder
                .Property(x => x.StatusOrder)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}