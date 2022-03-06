using System;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Infrastructure.Security;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EletronicECommerce.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User, UserModel>, IUserRepository
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        public UserRepository(EletronicECommerceContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
            _mapper = mapper; 
        }

        public User CheckUser(User user)
        {
            User userResponse = null;
            
            var userModel = _mapper.Map<UserModel>(user);
            
            userModel.SetPassword(PasswordHandler.EncryptPassword(userModel.Password));
            
            var userDto = _context.Users.AsNoTracking().FirstOrDefault(x => x.Email == userModel.Email && x.Password == userModel.Password);
            
            if(userDto != null)
            {
                userDto.SetPassword(PasswordHandler.DecryptPassword(userModel.Password));

                userResponse = _mapper.Map<User>(userDto);
            }
            
            return userResponse;
        }
        
        public override User Create(User user)
        {       
            var model = _mapper.Map<UserModel>(user);            

            base.Create(model, () => model.SetPassword(PasswordHandler.EncryptPassword(model.Password)));

            return user;
        }

        public User GetByEmail(string email) => 
            _mapper.Map<User>(_context.Users.AsNoTracking().FirstOrDefault(x => x.Email == email));

    }
}