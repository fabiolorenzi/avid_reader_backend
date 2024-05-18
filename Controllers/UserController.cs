using Microsoft.AspNetCore.Mvc;
using AvidReaderBackend.Data;
using AvidReaderBackend.Models;

namespace AvidReaderBackend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;
        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Create(User _user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(_user);
                _db.SaveChanges();
                return Ok(_user);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int _id)
        {
            var targetUser = _db.Users.Find(_id);

            if (targetUser == null)
            {
                return NotFound();
            }
            _db.Users.Remove(targetUser);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPatch]
        public IActionResult Login(User _user)
        {
            IEnumerable<User> users = _db.Users;
            foreach (User user in users)
            {
                if (user.Username == _user.Username && user.Password == _user.Password)
                {
                    return Ok(user);
                }
            }
            return NotFound();
        }
    }
}