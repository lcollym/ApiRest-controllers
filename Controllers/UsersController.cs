using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_controllers.DATA;
using Api_controllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private static List<Models.UserDTO> users = new List<Models.UserDTO>();

        [HttpGet]
        public IActionResult GetUsers()
        {
            Models.UserDTO user = new Models.UserDTO();
            user.Id = 1 ;
            user.FirstName = "luis";
            user.LastName = "collymoore";
            user.Email = "lcollymoore";

            users.Add(user);
            
            return Ok(users);

        }

        [HttpPost]
        public IActionResult AddUsers()
        {
            Models.UserDTO user = new Models.UserDTO();
            user.Id = 1 ;
            user.FirstName = "luis";
            user.LastName = "collymoore";
            user.Email = "lcollymoore";

            users.Add(user);
            
            return Ok(users);

        }
    }
}