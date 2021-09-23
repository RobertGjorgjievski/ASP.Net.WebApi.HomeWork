using MovieApp.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.DtoModels
{
    public  class DtoUser
    {
        public DtoUser()
        {
            Movies = new List<Movie>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Subscrition { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
