using LibraryManager.Models;

namespace LibraryManager.Services
{
    public class BookService : IBookService
    {
        private readonly IDbService _db;
        public BookService(IDbService db)
        {
            _db = db;
        }

        public void CreateBook(Book book)
        {
            _db.CreateBook(book);
        }

        public void DeleteBookById(int id)
        {
            _db.DeleteBookById(id);
        }

        public List<Book> GetAllBooks()
        {
            var books = _db.GetAllBooks();

            return books;
        }

        public Book GetBookById(int id)
        {
            var book = _db.GetBookById(id);

            return book;
        }
    }
}
