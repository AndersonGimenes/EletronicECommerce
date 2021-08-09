using System;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(EletronicECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Category Create(Category category)
        {
            var categoryModel = _mapper.Map<CategoryModel>(category);
            
            _context.Categories.Add(categoryModel);

            _context.SaveChanges();

            return category;
        }

        public Category GetByIdentifier(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Category GetByName(string name)
        {
            var categoryDto = _context.Categories.FirstOrDefault(x => x.Name == name);
            return _mapper.Map<Category>(categoryDto);
        }
    }
}