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

        [HttpPatch]
        public IActionResult Login(string _username, string _password)
        {
            IEnumerable<User> users = _db.Users;
            foreach (User user in users)
            {
                if (user.Username == _username && user.Password == _password)
                {
                    return Ok(user);
                }
            }
            return NotFound();
        }
    }
}