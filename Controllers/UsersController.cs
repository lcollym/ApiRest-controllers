using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_controllers.DATA;
using Api_controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Dapper;
namespace Api_controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly string _connectionString;

        public UsersController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Crear la tabla si no existe (opcional, puedes dejarlo fuera si no es necesario)
                // var createTableCmd = connection.CreateCommand();
                // createTableCmd.CommandText = @"
                //     CREATE TABLE IF NOT EXISTS Users (
                //         Id  INTEGER PRIMARY KEY AUTOINCREMENT,
                //         FirstName TEXT NOT NULL,
                //         LastName TEXT NOT NULL,
                //         Email TEXT NOT NULL
                //     )";
                // createTableCmd.ExecuteNonQuery();

                // Obtener los usuarios
                var getQuery = "SELECT * FROM Users";
                var users = connection.Query<DATA.UserDTO>(getQuery);

                return Ok(users);  // Devuelve la lista de usuarios
            }
        }


        [HttpPost]
        public IActionResult AddUsers([FromBody] DATA.UserDTO newUser)
        {
            if (newUser == null)
            {
                return BadRequest("Invalid user data.");
            }

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Insertar el nuevo usuario
                var insertQuery = "INSERT INTO Users (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email); SELECT last_insert_rowid();";
                var userId = connection.Execute(insertQuery, newUser);

                return Ok();
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromBody] DATA.UserDTO user)
        {
            if (user == null || user.Id == 0)
            {
                return BadRequest("Invalid user data.");
            }

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Consulta SQL correcta para eliminar un usuario
                var deleteQuery = "DELETE FROM Users WHERE Id = @Id;";

                // Ejecutar la consulta para eliminar el usuario
                var rowsAffected = connection.Execute(deleteQuery, new { Id = user.Id });

                if (rowsAffected > 0)
                {
                    return Ok("User deleted successfully.");
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
        }

    }
}