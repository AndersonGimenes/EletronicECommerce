using EletronicECommerce.Proxy.PaymentEngine;
using EletronicECommerce.UseCase.Interfaces.Proxies;
using Microsoft.Extensions.DependencyInjection;

namespace EletronicECommerce.DependencyInjection.Proxies
{
    internal static class ProxyDependencyInjection
    {
        internal static void ProxyDI(this IServiceCollection services)
        {
            services.AddTransient<IPaymentEngineProxy, PaymentEngineProxy>();
        }
    }
}