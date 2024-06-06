using AutoMapper;
using EcommerceAPI.Dto;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repository;
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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<User>))]
        public IActionResult GetUsers()
        {
            var products = _mapper.Map<ICollection<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUser(int id)
        {
            var users = _mapper.Map<UserDto>(_userRepository.GetById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(users);
        }

        [HttpGet("product/{userId}")]
        [ProducesResponseType(200, Type= typeof(ICollection<Product>))]
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
        [ProducesResponseType(404)]
        public IActionResult CreateUser(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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

        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser([FromBody] int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (_userRepository.GetById(id) == null)
                return NotFound();
            if (!_userRepository.DeleteUser(id))
            {
                ModelState.AddModelError("erro", "Servor Error");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
