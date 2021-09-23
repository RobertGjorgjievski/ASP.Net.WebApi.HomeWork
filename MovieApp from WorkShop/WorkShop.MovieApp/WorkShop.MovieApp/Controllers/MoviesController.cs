using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Domain.Enums;
using MovieApp.DtoModels;
using MovieApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkShop.MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/<MoviesController>
        [HttpGet]  //api/movies
        public ActionResult<List<DtoMovie>> GetAll()
        {
            try
            {
                return Ok(_movieService.GetAllMovies());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]  // GET: api/movies/1
        public ActionResult<DtoMovie> GetById(int id)
        {
            try
            {
                return Ok(_movieService.GetById(id));
            }
            catch ( Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // Get api/<MoviesController>
        [HttpGet("genre")] // api/movies/genre?Genre=Action
        public ActionResult <DtoMovie> GetByGenre ([FromQuery] Genre genre )
        {
            try
            {
                return Ok(_movieService.GetByGenre(genre));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost] // POST: api/movies
        public ActionResult<string> Post([FromBody] DtoMovie entity )
        {
            try
            {
                _movieService.Add(entity);
                return StatusCode(StatusCodes.Status201Created, new { Message = "Movie was created succesfully" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, new { ex.Message });
            }
        }

        [HttpPut("update")] //api/movies/update
        public ActionResult <string> Put( [FromBody] DtoMovie dtoMovie)
        {
            try
            {
                _movieService.Update(dtoMovie);
                return StatusCode(StatusCodes.Status202Accepted, new{Message ="Movie was succesfully updated" } );
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")] // api/movies/1
        public ActionResult <string> Delete(int id)
        {
            try
            {
                return Ok( _movieService.Delete(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            } 
        }
    }
}
