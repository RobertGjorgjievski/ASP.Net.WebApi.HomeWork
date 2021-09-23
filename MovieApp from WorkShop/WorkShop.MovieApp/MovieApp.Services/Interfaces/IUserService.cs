using MovieApp.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services.Interfaces
{
    public interface IUserService
    {
        List<DtoUser> GetAll();
        DtoUser GetById(int id);
        string Create(DtoUser user);
       // Get all user's movies rented
    }
}
