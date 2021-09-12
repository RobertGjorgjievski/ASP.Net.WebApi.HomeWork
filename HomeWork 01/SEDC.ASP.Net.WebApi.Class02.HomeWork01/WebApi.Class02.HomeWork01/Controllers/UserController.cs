using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Class02.HomeWork01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private static List<Users> users = new List<Users>()
        {
            new Users()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobsky",
                Age = 30
            },
            new Users()
            {
                Id = 2,
                FirstName = "John",
                LastName = "Doe",
                Age = 17
            },
            new Users()
            {
                Id = 3,
                FirstName = "Bruce",
                LastName = "Wayne",
                Age = 35
            },
            new Users()
            {
                Id = 4,
                FirstName = "King",
                LastName = "Shark",
                Age = 30
            },
            new Users()
            {
                Id =5,
                FirstName = "Lex",
                LastName = "Lutohor",
                Age = 15
            },
            new Users()
            {
                Id = 6,
                FirstName = "Clark",
                LastName = "Kent",
                Age = 56
            }
        };


        [HttpGet("all")]   // api/user/all
        public ActionResult<List<Users>> GetAll()
        {
            return Ok(users);
        }


        [HttpGet("userIndex/{userIndex}")]   //api/user/userIndex/1
        public ActionResult<Users> GetUserByIndex(int userIndex)
        {

            try
            {
                if (userIndex > 6)
                {
                    throw new Exception();
                }
                return users[userIndex];
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, new { Message = ex.Message });
            }

        }

        [HttpGet("aduld/{id}")]  //api/user/aduld/1
        public ActionResult<Users> AduldUser(int id)
        {
            try
            {
                if (id == 0 || id > 6)
                {
                    throw new Exception();
                }


                Users idUser =  users.SingleOrDefault(user => user.Id == id);
                if (idUser.Age < 18)
                {
                    return StatusCode(StatusCodes.Status200OK, new { Message = "This user is not aduld." });
                }
                return StatusCode(StatusCodes.Status200OK, new { Message = "This user is aduld." }); 
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { Message = $"No user with id: {id}", suggestion = 1});
            }
        }
    
        [HttpPost("addNewUser")] //api/user/addNewUser
        public ActionResult<Users> addNewUser([FromBody]Users addNewUser)
        {
            int id = users.Count + 1;
            addNewUser.Id = id;
            users.Add(addNewUser);
            return StatusCode(StatusCodes.Status201Created, addNewUser);
        }
       
    }
}
