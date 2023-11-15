using LibraryManager.Models;
using LibraryManager.Models.DTOs;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Route("/CreateBook")]
        public IActionResult CreateBook([FromBody] BookDTO book)
        {
            var bookToCreate = new Book()
            {
                ISBN = book.ISBN,
                Title = book.Title,
                Stock = book.Stock,
                Author = book.Author,
                ReleaseYear = book.ReleaseYear
            };

            _bookService.CreateBook(bookToCreate);

            return Ok(book);
        }

        [HttpGet]
        [Route("/GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();

            return Ok(books);
        }

        [HttpGet]
        [Route("/GetBookById")]
        public IActionResult GetBookById(int id)
        {
            Book book = _bookService.GetBookById(id);

            return Ok(book);
        }

        [HttpDelete]
        [Route("/DeleteBookById")]
        public IActionResult DeleteBookById(int id)
        {
            _bookService.DeleteBookById(id);

            return Ok();
        }
    }
}
