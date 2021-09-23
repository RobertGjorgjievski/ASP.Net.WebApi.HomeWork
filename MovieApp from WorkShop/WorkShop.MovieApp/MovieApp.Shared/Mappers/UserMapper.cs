using MovieApp.Domain.DbModels;
using MovieApp.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Shared.Mappers
{
    public static class UserMapper
    {
        public static User DtoUserToUser (DtoUser dtoUser)
        {
            return new User()
            {
                Id = dtoUser.Id,
                FullName = dtoUser.FullName,
                Username = dtoUser.Username,
                Password = dtoUser.Password,
                Subscrition = dtoUser.Subscrition,
            };

        }
       public static DtoUser UserToDtoUser(User user)
        {
            return new DtoUser()
            {
                Id = user.Id,
                FullName = user.FullName,
                Username = user.Username,
                Password = user.Password,
                Subscrition = user.Subscrition
            };
        }
    }
}
