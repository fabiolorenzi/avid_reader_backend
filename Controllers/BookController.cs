using Microsoft.AspNetCore.Mvc;
using AvidReaderBackend.Data;
using AvidReaderBackend.Models;

namespace AvidReaderBackend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDBContext _db;
        public BookController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet("Get")]
        public IActionResult GetAll()
        {
            IEnumerable<Book> books = _db.Books;
            return Ok(books);
        }

        [HttpGet("Get/{_id}")]
        public IActionResult GetById(int _id)
        {
            var targetBook = _db.Books.Find(_id);

            if (targetBook == null)
            {
                return NotFound();
            }
            return Ok(targetBook);
        }

        [HttpPost]
        public IActionResult Create(Book _book)
        {
            if (ModelState.IsValid)
            {
                _db.Books.Add(_book);
                _db.SaveChanges();
                return Ok(_book);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit(Book _book){
            if (ModelState.IsValid)
            {
                _db.Books.Update(_book);
                _db.SaveChanges();
                return Ok(_book);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int _id)
        {
            var targetBook = _db.Books.Find(_id);

            if (targetBook == null)
            {
                return NotFound();
            }
            _db.Books.Remove(targetBook);
            _db.SaveChanges();
            return Ok();
        }
    }
}