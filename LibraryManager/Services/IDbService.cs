using LibraryManager.Models;

namespace LibraryManager.Services
{
    public interface IDbService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void DeleteBookById(int id);
        int GetBookStock(int bookId);

        void CreateUser(User user);

        void RentBook(Loan loan);
        void ReturnBook(int bookId);
        List<Loan> GetAllUserLoans(int userId);
    }
}
