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
        public bool CanUserRentBook(int userId, int bookId)
        {
            var loans = _db.GetAllUserLoans(userId);

            if (loans.Count() >= 3) return false; //falar q o user não pode alugar mais livros

            if (loans.Any(x => x.BookId == bookId)) return false; //falar q o user não pode alugar o mesmo livro já tendo um igual alugado

            return true;
        }
    }
}
