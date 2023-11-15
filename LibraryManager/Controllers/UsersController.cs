using LibraryManager.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using LibraryManager.Models;
using LibraryManager.Services;

namespace LibraryManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/CreateUser")]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            var userToCreate = new User()
            {
                Name = user.Name,
                Email = user.Email,
            };

            _userService.CreateUser(userToCreate);

            return Ok(user);
        }
    }
}
