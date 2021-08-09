using EletronicECommerce.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class CategoryModelConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder
                .ToTable("Category");

            builder
                .HasKey(x  => x.Id)
                .HasName("Pk_Category");

            builder
                .Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}