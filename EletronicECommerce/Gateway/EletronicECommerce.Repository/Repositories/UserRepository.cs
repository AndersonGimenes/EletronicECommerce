using System;
using System.Linq;
using AutoMapper;
using EletronicECommerce.Domain.Entities.Shared;
using EletronicECommerce.Infrastructure.Security;
using EletronicECommerce.Repository.Context;
using EletronicECommerce.Repository.Models;
using EletronicECommerce.UseCase.Interfaces.Repositories;

namespace EletronicECommerce.Repository.Repositories
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        private readonly EletronicECommerceContext _context;
        private readonly IMapper _mapper;

        public UserRepository(EletronicECommerceContext context, IMapper mapper)
            : base(context)
        {
            _context = context;
            _mapper = mapper;
        }

        public User CheckUser(User user)
        {
            User userResponse = null;
            
            var userModel = _mapper.Map<UserModel>(user);
            
            userModel.SetPassword(PasswordHandler.EncryptPassword(userModel.Password));
            
            var userDto = _context.Users.FirstOrDefault(x => x.Email == userModel.Email && x.Password == userModel.Password);
            
            if(userDto != null)
            {
                userDto.SetPassword(PasswordHandler.DecryptPassword(userModel.Password));

                userResponse = _mapper.Map<User>(userDto);
            }
            
            return userResponse;
        }
        
        public User Create(User user)
        {       
            var userModel = _mapper.Map<UserModel>(user);
            
            userModel.SetPassword(PasswordHandler.EncryptPassword(userModel.Password));
                
            _context.Users.Add(userModel);

            base.Create(userModel);

            return user;
        }

        public User GetByEmail(string email) => 
            _mapper.Map<User>(_context.Users.FirstOrDefault(x => x.Email == email));

        public User GetByIdentifier(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public User GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}