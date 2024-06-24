using AutoMapper;
using EcommerceAPI.Dto;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EcommerceAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUser(int id)
        {
            var user = _mapper.Map<UserDtoNoPassword>(_userRepository.GetById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(user);
        }

        [HttpGet("product/{userId}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        [ProducesResponseType(404)]
        public IActionResult GetProductByUser(int userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_userRepository.GetById(userId) == null)
                return NotFound();

            var products = _mapper.Map<ICollection<ProductDto>>(_userRepository.GetProductByUser(userId));

            return Ok(products);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_userRepository.ExistUserByEmail(user.Email))
            {
                ModelState.AddModelError("Error", "Email already in use");
                return Conflict(ModelState);
            }

            if (!_userRepository.CreateUser(user))
                return StatusCode(500, ModelState);
            return Ok("Successfully created!");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser(UserDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userdto = _mapper.Map<User>(user);

            if (!_userRepository.UpdateUser(userdto))
                return StatusCode(500, ModelState);

            return NoContent();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_userRepository.GetById(userId) == null)
                return NotFound();
            if (!_userRepository.DeleteUser(userId))
            {
                ModelState.AddModelError("erro", "Servor Error");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
