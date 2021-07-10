using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EletronicECommerce.Repository.Factory
{
    public class EletronicECommerceContextFactory : IDesignTimeDbContextFactory<EletronicECommerceContext>
    {
        public EletronicECommerceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EletronicECommerceContext>();
            optionsBuilder.UseMySQL(Settings.ConnectionString);

            return new EletronicECommerceContext(optionsBuilder.Options);
        }
    }
}