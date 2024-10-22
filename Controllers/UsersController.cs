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
            return Ok(users);  // Devuelve la lista de usuarios actual
        }

        [HttpPost]
        public IActionResult AddUsers([FromBody] Models.UserDTO newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid user data.");
            }

            // Asignar valores a las propiedades del nuevo usuario.
            Models.UserDTO user = new Models.UserDTO
            {
                Id = Guid.NewGuid(),  // Generar un identificador único para el usuario.
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email
            };

            // Asumiendo que 'users' es una lista de usuarios que ya está inicializada.
            users.Add(user);

            return Ok(users);
        }

    

   [HttpDelete]
public IActionResult DeleteUsers([FromBody] Models.UserDTO userToDelete)
{
    if (userToDelete == null || userToDelete.Id == Guid.Empty)
    {
        return BadRequest("Invalid user data.");
    }

    // Buscar al usuario en la lista por su Id
    var user = users.FirstOrDefault(u => u.Id == userToDelete.Id);

    if (user == null)
    {
        return NotFound("User not found.");
    }

    // Eliminar el usuario de la lista
    users.Remove(user);

    return Ok(users);
}

}
}