using LibraryManager.Models;

namespace LibraryManager.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        bool CanUserRentBook(int userId, int bookId);
    }
}