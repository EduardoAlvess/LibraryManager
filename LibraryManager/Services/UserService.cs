using LibraryManager.Models;

namespace LibraryManager.Services
{
    public class UserService : IUserService
    {
        private readonly IDbService _db;

        public UserService(IDbService db)
        {
            _db = db;
        }

        public void CreateUser(User user)
        {
            _db.CreateUser(user);
        }
        public bool CanUserRentBook(int userId)
        {
            var loans = _db.GetAllUserLoans(userId);

            if (loans.Count() >= 3) return false;

            return true;
        }
    }
}
