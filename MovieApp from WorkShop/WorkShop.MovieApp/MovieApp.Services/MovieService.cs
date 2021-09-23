using MovieApp.DataAccess;
using MovieApp.Domain.DbModels;
using MovieApp.Domain.Enums;
using MovieApp.DtoModels;
using MovieApp.Services.Interfaces;
using MovieApp.Shared.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.Services
{
    public class MovieService : IMovieService
    {

        private readonly IRepository<Movie> _movieRepo;
        public MovieService(IRepository<Movie> movieRepo)
        {
            _movieRepo = movieRepo;
        }

        public string Add(DtoMovie entity)
        {
            Movie movie = MovieMapper.DtoMovieToMovie(entity);
            if(movie.Title == string.Empty)
            {
                throw new Exception("Title is Required "); 
            }
            _movieRepo.Add(movie);
            return "Movie was created succesfully.";
        }

        public string Delete(int id)
        {
            Movie movie = _movieRepo.GetBYId(id);
            if(movie == null)
            {
                throw new Exception("No such movie with  that Id");
            }
            _movieRepo.Delete(id);
            return "The movie was succesfully delete";
        }

        public List<DtoMovie> GetAllMovies()
        {
            List<Movie> movies = _movieRepo.GetAll();
            List<DtoMovie> dtoMovies = movies.Select(movie => MovieMapper.MovieToDtoMovie(movie)).ToList();
            return dtoMovies;
        }

        public List<DtoMovie> GetByGenre(Genre genre)
        {
            List<Movie> movies = _movieRepo.GetAll();
            List<DtoMovie> dtoMovies = movies.Where(movie => movie.Genre == genre)
                                             .Select(movie => MovieMapper.MovieToDtoMovie(movie))
                                             .ToList();
            return dtoMovies;
        }

        public DtoMovie GetById(int id)
        {
            Movie movie = _movieRepo.GetBYId(id);
            if(movie == null)
            {
                throw new Exception("No such movie by that id");
            }
            return MovieMapper.MovieToDtoMovie(movie);
        }

        public string Update(DtoMovie entity)
        {
            Movie movie = _movieRepo.GetBYId(entity.Id);
            if (movie == null)
            {
                throw new Exception("No such movie with that Id ");
            }
            Movie mappet = MovieMapper.DtoMovieToMovie(entity);
            _movieRepo.Update(mappet);
            return "The movie was succesfully updated";
        }
    }
}
