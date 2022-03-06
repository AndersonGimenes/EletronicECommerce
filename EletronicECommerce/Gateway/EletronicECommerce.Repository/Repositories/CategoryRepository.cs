using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EletronicECommerce.Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<Category, CategoryModel>, ICategoryRepository
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(EletronicECommerceContext context, IMapper mapper) 
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Category GetByName(string name)
        {
            var categoryDto = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Name == name);
            return _mapper.Map<Category>(categoryDto);
        }
    }
}