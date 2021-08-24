using System;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class ProductRepository : RepositoryBase<ProductModel>,  IProductRepository
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(EletronicECommerceContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Product Create(Product product)
        {
            var productModel = _mapper.Map<ProductModel>(product);

            _context.Products.Add(productModel);

            base.Create(productModel);

            return product;
        }

        public Product GetByCode(string code)
        {
            var productDto = _context.Products.FirstOrDefault(x => x.Code == code);

            return _mapper.Map<Product>(productDto);
        }

        public Product GetByIdentifier(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Product GetByName(string name)
        {
            var productDto = _context.Products.FirstOrDefault(x => x.Name == name);

            return _mapper.Map<Product>(productDto);
        }
    }
}