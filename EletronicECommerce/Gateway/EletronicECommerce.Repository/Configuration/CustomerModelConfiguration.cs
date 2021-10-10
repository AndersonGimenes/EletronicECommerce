using EletronicECommerce.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class CustomerModelConfiguration : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder
                .ToTable("Customer");

            builder
                .HasKey(x  => x.Id)
                .HasName("Pk_User");

            builder
                .Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .Property(x => x.FirstName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.Surname)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(x => x.DocumentNumber)
                .HasColumnType("varchar(14)")
                .IsRequired();

            builder
                .Property(x => x.DocumentType)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.User)
                .HasColumnType("char(36)")
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}