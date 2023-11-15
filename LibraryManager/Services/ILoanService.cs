using LibraryManager.Models;

namespace LibraryManager.Services
{
    public interface ILoanService
    {
        string RentBook(Loan loan);
        void ReturnBook(int bookId);
    }
}