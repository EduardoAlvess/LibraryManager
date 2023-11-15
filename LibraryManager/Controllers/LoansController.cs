using LibraryManager.Models.DTOs;
using LibraryManager.Models;
using LibraryManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Controllers
{
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost]
        [Route("/RentBook")]
        public IActionResult RentBook([FromBody] LoanDTO loan)
        {
            var loanToCreate = new Loan()
            {
                UserId = loan.UserId,
                BookId = loan.BookId,
            };

            string response = _loanService.RentBook(loanToCreate);

            return Ok(response);
        }

        [HttpDelete]
        [Route("/ReturnBook")]
        public IActionResult ReturnBook(int bookId)
        {
            _loanService.ReturnBook(bookId);

            return Ok();
        }
    }
}
