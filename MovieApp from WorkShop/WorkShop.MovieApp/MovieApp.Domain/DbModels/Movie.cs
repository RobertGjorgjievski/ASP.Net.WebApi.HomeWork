using MovieApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Domain.DbModels
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
