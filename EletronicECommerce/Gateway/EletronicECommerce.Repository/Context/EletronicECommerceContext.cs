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
        
        internal DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
    }
}