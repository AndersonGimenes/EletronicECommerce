using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EletronicECommerce.Domain.DTOs;
using EletronicECommerce.Infrastructure.Config;
using EletronicECommerce.Proxy.Exceptions;
using EletronicECommerce.Proxy.Model.Cielo;
using EletronicECommerce.UseCase.Interfaces.Proxies;
using Newtonsoft.Json;

namespace EletronicECommerce.Proxy.PaymentEngine
{
    public class PaymentEngineProxy : IPaymentEngineProxy
    {
        private readonly IMapper _mapper;

        public PaymentEngineProxy(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public async Task<object> SendPayment(Payment payment)
        {
            var result = string.Empty;
            var request = _mapper.Map<CieloPaymentRequest>(payment);
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.UriBaseCielo);
                client.DefaultRequestHeaders.Add(nameof(Settings.MerchantId), Settings.MerchantId);
                client.DefaultRequestHeaders.Add(nameof(Settings.MerchantKey), Settings.MerchantKey);

                var response = await client.PostAsync("1/sales", data);

                if(response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                    throw new ProxyException("The payment could not be process!");
                    
                result = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<object>(result);
        }

    }
}