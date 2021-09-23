using MovieApp.Domain.Enums;
using MovieApp.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        List<DtoMovie> GetAllMovies();
        DtoMovie GetById(int id);
        List<DtoMovie> GetByGenre(Genre genre);
        string Add(DtoMovie entity);
        string Delete(int id);
        string Update(DtoMovie entity);

    }
}
