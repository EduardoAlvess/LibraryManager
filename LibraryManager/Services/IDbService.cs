using LibraryManager.Models;

namespace LibraryManager.Services
{
    public interface IDbService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void DeleteBookById(int id);
    }
}
