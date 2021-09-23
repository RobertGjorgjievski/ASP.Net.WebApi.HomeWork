using MovieApp.Domain;
using MovieApp.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieApp.DataAccess
{
    public class MovieRepository : IRepository<Movie>
    {

        private readonly MovieAppDbContext _dbContext;
        public MovieRepository(MovieAppDbContext context)
        {
            _dbContext = context;
        }


        public void Add(Movie entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Movie movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            if(movie == null)
            {
                throw new Exception("No such movie");
            }
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

        }

        public List<Movie> GetAll()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie GetBYId(int id)
        {
            Movie movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            if(movie == null)
            {
                throw new Exception("No such movie with that Id");
            }
            return movie;
        }

        public void Update(Movie entity)
        {
            Movie movie = _dbContext.Movies.SingleOrDefault(x => x.Id == entity.Id);
            if (movie == null)
            {
                throw new Exception("No such movie with that Id");
            }
            movie.Title = entity.Title;
            movie.Year = entity.Year;
            movie.Genre = entity.Genre;
            _dbContext.SaveChanges();
        }
    }
}
