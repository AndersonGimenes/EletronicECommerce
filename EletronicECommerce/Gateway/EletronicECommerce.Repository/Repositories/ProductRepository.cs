using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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

                base.SaveChanges();

                return product;
            }

            base.Create(model);

            base.SaveChanges();
            
            return product;
        }

        public Product GetByCode(string code)
        {
            var productDto = _context.Products.AsNoTracking().FirstOrDefault(x => x.Code == code);

            return _mapper.Map<Product>(productDto);
        }

        public Product GetByName(string name)
        {
            var productDto = _context.Products.AsNoTracking().FirstOrDefault(x => x.Name == name);

            return _mapper.Map<Product>(productDto);
        }

        public IEnumerable<Product> GetProductsByIds(IEnumerable<Guid> guids)
        {
            var products = _context.Products.AsNoTracking().Where(x => guids.Contains(x.Id)).ToList();
            var stocks = _context.Stocks.AsNoTracking().Where(x => guids.Contains(x.Product)).ToList();

            if(stocks.Any()) 
                foreach(var product in products)
                {
                    product.SetStock(stocks.FirstOrDefault(x => product.Id == x.Product));
                }

            return _mapper.Map<IEnumerable<Product>>(products);
        }
    }
}