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

        [HttpGet]
        public IActionResult GetAll([FromQuery(Name = "filter")] string? filterQuery, [FromQuery(Name = "user")] int userId)
        {
            IEnumerable<Book> books = _db.Books.Where(book => book.UserId == userId);
            
            if (filterQuery != null)
            {
                var filteredBooks = books.Where(book => 
                    book.Author.ToLower().Contains(filterQuery.ToLower()) || 
                    book.Title.ToLower().Contains(filterQuery.ToLower())
                );
                return Ok(filteredBooks);
            }
            return Ok(books);
        }

        [HttpGet("{_id}")]
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

        [HttpDelete("{_id}")]
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