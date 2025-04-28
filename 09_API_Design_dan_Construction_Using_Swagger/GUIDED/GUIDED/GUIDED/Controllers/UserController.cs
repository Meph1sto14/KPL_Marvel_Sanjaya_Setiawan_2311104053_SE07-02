using GUIDED.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GUIDED.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User{id = 1, name = "alisa", email="alisa@gmail.com"},
            new User{id = 2, name = "bob", email="bob@gmail.com"},
        };

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id) 
        {
            var user = users.FirstOrDefault(x => x.id == id);
            if (user == null) 
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(UserDto userCreate)
        {
            int new_id = users.Count + 1;
            User user = new User
            {
                id = new_id,
                name = userCreate.name,
                email = userCreate.email
            };
            users.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDto userUpdate)
        {
            var user = users.FirstOrDefault(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.name = userUpdate.name;
            user.email = userUpdate.email;
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(x => x.id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return NoContent();
        }
    }
}
