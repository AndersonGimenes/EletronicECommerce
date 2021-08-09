using System.Reflection;
using EletronicECommerce.Repository.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}