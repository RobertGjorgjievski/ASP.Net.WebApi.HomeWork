using MovieApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.DtoModels
{
    public class DtoMovie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}
