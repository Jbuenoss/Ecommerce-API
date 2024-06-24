using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EcommerceAPI.Models;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Dto;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly IUserRepository _userRepository;
        public AccountController(TokenService tokenService, IUserRepository userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        [HttpPost("v1/login")]
        public IActionResult Index([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(!_userRepository.ExistUserByEmail(user.Email))
            {
                ModelState.AddModelError("Error", "user or password invalid");
                return StatusCode(401, ModelState);
            }
            User foundUser = _userRepository.GetByEmail(user.Email);
            if (foundUser.Password != user.Password)
            {
                ModelState.AddModelError("Error", "user or password invalid");
                return StatusCode(401, ModelState);
            }

            var token = _tokenService.GenerateToken(foundUser);
            return Ok(token);
        }

    }
}
