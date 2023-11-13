using Dapper;
using LibraryManager.Models;
using MySqlConnector;
using System.Buffers;
using System.Data.SqlClient;

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
                    ReleaseYear = book.ReleaseYear
                };

                const string query = "INSERT INTO Books (Title, Author, ISBN, ReleaseYear) VALUES (@Title, @Author, @ISBN, @ReleaseYear)";

                var result = dbConnection.ExecuteAsync(query, parameters);
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

                const string query = "DELETE * FROM Books WHERE Id = @Id";

                var result = dbConnection.ExecuteAsync(query, paremeters);
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
    }
}
