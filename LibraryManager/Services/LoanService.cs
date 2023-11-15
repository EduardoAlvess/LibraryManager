﻿using LibraryManager.Models;

namespace LibraryManager.Services
{
    public class LoanService : ILoanService
    {
        private readonly IDbService _db;
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public LoanService(IDbService db, IBookService bookService, IUserService userService)
        {
            _db = db;
            _bookService = bookService;
            _userService = userService;
        }

        public string RentBook(Loan loan)
        {
            if (_userService.CanUserRentBook(loan.UserId) && _bookService.IsBookavailable(loan.BookId))
            {
                loan.LoanDate = DateTime.Now;
                loan.ReturnDate = DateTime.Now.AddMonths(1);

                _db.RentBook(loan);

                return $"Livro {loan.BookId} alugado!";
            }

            return $"Livro sem estoque, não foi possível alugar";
        }

        public void ReturnBook(int bookId)
        {
            _db.ReturnBook(bookId);
        }
    }
}
