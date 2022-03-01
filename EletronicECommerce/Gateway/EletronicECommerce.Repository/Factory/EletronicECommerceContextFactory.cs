using EletronicECommerce.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EletronicECommerce.Repository.Factory
{
    internal class EletronicECommerceContextFactory : IDesignTimeDbContextFactory<EletronicECommerceContext>
    {
        public EletronicECommerceContext CreateDbContext(string[] args)
        {
            // When use migrations, put connection string here
            var optionsBuilder = new DbContextOptionsBuilder<EletronicECommerceContext>();
            optionsBuilder.UseMySQL("");

            return new EletronicECommerceContext(optionsBuilder.Options);
        }
    }
}