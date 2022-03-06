using System.Reflection;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.Repository.Models.SubModels;
using Microsoft.EntityFrameworkCore;

namespace EletronicECommerce.Repository.Context
{
    public class EletronicECommerceContext : DbContext
    {
        public EletronicECommerceContext(DbContextOptions options)
            : base(options) 
        {
            
        }
        
        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderProductModel> OrdersProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}