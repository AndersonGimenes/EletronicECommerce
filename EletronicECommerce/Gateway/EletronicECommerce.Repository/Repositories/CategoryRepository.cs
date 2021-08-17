using System;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Admin;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class CategoryRepository : RepositoryBase<CategoryModel>, ICategoryRepository
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(EletronicECommerceContext context, IMapper mapper) 
            : base(context)
        {
            _context = context;
            _mapper = mapper;
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

        public Category Create(Category category)
        {
            var categoryModel = _mapper.Map<CategoryModel>(category);
            
            _context.Categories.Add(categoryModel);
            
            base.Create(categoryModel);

            return category;
        }
    }
}