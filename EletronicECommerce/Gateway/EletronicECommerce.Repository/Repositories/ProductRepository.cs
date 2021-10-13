using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class ProductRepository : RepositoryBase<Product, ProductModel>,  IProductRepository
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(EletronicECommerceContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override Product Create(Product product)
        {       
            var model = _mapper.Map<ProductModel>(product).CompleteMapper();
           
            if(model.Stock != null)
            {
                base.Create(model, () => 
                    _context.Stocks.Add(model.Stock)
                );

                return product;
            }

            base.Create(model);
            
            return product;
        }

        public Product GetByCode(string code)
        {
            var productDto = _context.Products.FirstOrDefault(x => x.Code == code);

            return _mapper.Map<Product>(productDto);
        }

        public Product GetByName(string name)
        {
            var productDto = _context.Products.FirstOrDefault(x => x.Name == name);

            return _mapper.Map<Product>(productDto);
        }
    }
}