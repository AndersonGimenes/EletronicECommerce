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
                .Property(x => x.TotalPrice)
                .HasColumnType("decimal(15,2)")
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

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasConstraintName("Fk_Order_User")
                .HasForeignKey("UserId");
        }
    }
}