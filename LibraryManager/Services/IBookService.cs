﻿using LibraryManager.Models;

namespace LibraryManager.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void DeleteBookById(int id);
        bool IsBookAvailable(int bookId);
    }
}
