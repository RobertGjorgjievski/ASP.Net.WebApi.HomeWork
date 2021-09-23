using MovieApp.Domain.DbModels;
using MovieApp.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.Shared.Mappers
{
    public class MovieMapper
    {

            public static Movie DtoMovieToMovie(DtoMovie dtoMovie)
            {
                return new Movie()
                {
                    Id = dtoMovie.Id,
                    Title = dtoMovie.Title,
                    Year = dtoMovie.Year,
                    Genre = dtoMovie.Genre
                };
            }

            public static DtoMovie MovieToDtoMovie(Movie movie)
            {
                return new DtoMovie()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    Genre = movie.Genre
                };
            }
        }
    }

