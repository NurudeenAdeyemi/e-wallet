using ewallet.DTOs;
using ewallet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ewallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser(RegisterUserRequest request)
        {
            var result = _userService.RegisterUser(request);
            return Ok(result);
        }
    }
}
