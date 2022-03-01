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
            var products = _context.Products.AsNoTracking().Include(x => x.Stocks).Where(x => guids.Contains(x.Id));

            return _mapper.Map<IEnumerable<Product>>(products);
        }
    }
}