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

        private static List<Users> users = new List<Users>();

        [HttpGet]
        public IActionResult GetUsers()
        {
            Users user = new Users();
            user.Id = 1 ;
            user.FirstName = "luis";
            user.LastName = "collymoore";
            user.Email = "lcollymoore";
            
            
            return Ok(user);

        }
    }
}