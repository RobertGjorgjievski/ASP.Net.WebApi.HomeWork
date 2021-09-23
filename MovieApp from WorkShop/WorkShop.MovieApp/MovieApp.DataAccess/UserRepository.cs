using MovieApp.Domain;
using MovieApp.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.DataAccess
{
    public class UserRepository : IRepository<User>
    {
        private readonly MovieAppDbContext _dbContext;
        public UserRepository( MovieAppDbContext context )
        {
            _dbContext = context;
        }

        public void Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception("No such user");
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetBYId(int id)
        {
            User user = _dbContext.Users.SingleOrDefault(x => x.Id == id);
            if(user == null)
            {
                throw new Exception("No such user with that Id.");
            }
            return user;
        }

        public void Update(User entity)
        {
            User user = _dbContext.Users.SingleOrDefault(x => x.Id == entity.Id);
            if (user == null)
            {
                throw new Exception("No such user with that Id.");
            }
            user.FullName = entity.FullName;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.Subscrition = entity.Subscrition;
            _dbContext.SaveChanges();
        }
    }
}
