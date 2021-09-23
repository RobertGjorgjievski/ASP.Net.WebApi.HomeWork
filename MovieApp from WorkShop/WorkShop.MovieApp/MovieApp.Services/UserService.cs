using MovieApp.DataAccess;
using MovieApp.Domain.DbModels;
using MovieApp.DtoModels;
using MovieApp.Services.Interfaces;
using System;
using MovieApp.Shared.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;
        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public string Create(DtoUser dtoUser)
        {
            User user = UserMapper.DtoUserToUser(dtoUser);
            if(user == null)
            {
                throw new Exception("Enter context for user");
            }
            _userRepo.Add(user);
            return "User succesfolly created.";
        }

        public List<DtoUser> GetAll()
        {
            return _userRepo.GetAll().Select(user => UserMapper.UserToDtoUser(user)).ToList();
        }

        public DtoUser GetById(int id)
        {
            User user = _userRepo.GetBYId(id);
            if(user == null)
            {
                throw new Exception("No such user with that id");
            }
            return UserMapper.UserToDtoUser(user);
        }
    }
}
