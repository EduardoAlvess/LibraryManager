using Dapper;
using LibraryManager.Models;
using MySqlConnector;
using System.Net;

namespace LibraryManager.Services
{
    public class DapperDbService : IDbService
    {
        private readonly string _connectionString = "Server=localhost;Database=default;Uid=root;Pwd=12345";

        public void CreateBook(Book book)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var parameters = new
                {
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    ReleaseYear = book.ReleaseYear,
                    Stock = book.Stock
                };

                const string query = "INSERT INTO Books (Title, Author, ISBN, ReleaseYear, Stock) VALUES (@Title, @Author, @ISBN, @ReleaseYear, @Stock)";

                dbConnection.Execute(query, parameters);
            }
        }

        public void DeleteBookById(int id)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    Id = id
                };

                const string query = "DELETE FROM Books WHERE Id = @Id";

                dbConnection.Execute(query, paremeters);
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                const string query = "SELECT * FROM Books";

                var result = dbConnection.QueryAsync<Book>(query);

                var books = result.Result.ToList();

                return books;
            }
        }

        public Book GetBookById(int id)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    Id = id
                };

                const string query = "SELECT * FROM Books WHERE Id = @Id";

                var book = dbConnection.QuerySingleOrDefault<Book>(query, paremeters);

                return book;
            }
        }

        public void CreateUser(User user)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    Name = user.Name,
                    Email = user.Email
                };

                const string query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";

                dbConnection.Execute(query, paremeters);
            }
        }

        public void RentBook(Loan loan)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    UserId = loan.UserId,
                    BookId = loan.BookId,
                    LoanDate = loan.LoanDate,
                    ReturnDate = loan.ReturnDate,
                };

                const string query = "INSERT INTO Loans (UserId, BookId, LoanDate, ReturnDate) VALUES (@UserId, @BookId, @LoanDate, @ReturnDate)";

                dbConnection.Execute(query, paremeters);
            }

            ChangeBookStock(loan.BookId, -1);
        }

        public void ReturnBook(int bookId)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    BookId = bookId
                };

                const string query = "DELETE FROM Loans WHERE BookId = @BookId";

                dbConnection.Execute(query, paremeters);
            }

            ChangeBookStock(bookId, 1);
        }

        public int GetBookStock(int bookId)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    BookId = bookId,
                };

                const string query = "SELECT Stock FROM Books WHERE Id = @BookId";

                int stock = dbConnection.QuerySingleOrDefault<int>(query, paremeters);

                return stock;
            }
        }

        private void ChangeBookStock(int bookId, int quantity)
        {
            int stock = GetBookStock(bookId);

            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    BookId = bookId,
                    Stock = stock + quantity,
                };

                const string query = "UPDATE Books SET Stock = @Stock WHERE Id = @BookId";

                dbConnection.Execute(query, paremeters);
            }
        }

        public List<Loan> GetAllUserLoans(int userId)
        {
            using (var dbConnection = new MySqlConnection(_connectionString))
            {
                var paremeters = new
                {
                    UserId = userId,
                };

                const string query = "SELECT * FROM Loans WHERE UserId = @UserId";

                var result = dbConnection.QueryAsync<Loan>(query, paremeters).Result;

                var loans = result.ToList();

                return loans;
            }
        }
    }
}
