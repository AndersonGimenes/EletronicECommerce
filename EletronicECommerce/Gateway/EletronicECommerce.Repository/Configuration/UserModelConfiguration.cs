using EletronicECommerce.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EletronicECommerce.Repository.Configuration
{
    internal class UserModelConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(x  => x.Id)
                .HasName("Pk_User");

            builder
                .Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder
                .Property(x => x.CreateDate)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}