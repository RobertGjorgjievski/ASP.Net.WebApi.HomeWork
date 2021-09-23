using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet] // api/users
        public ActionResult<List<DtoUser>> GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
                
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")] //api/user/1
        public ActionResult GetById(int id)
        {
            try
            {
              return Ok(_userService.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
          
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] DtoUser user)
        {
            try
            {
                _userService.Create(user);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

       
    }
}
