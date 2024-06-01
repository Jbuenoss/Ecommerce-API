using AutoMapper;
using EcommerceAPI.Dto;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
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
        [ProducesResponseType(200, Type=typeof(User))]
        public IActionResult GetUser(int id)
        {
            var product = _mapper.Map<UserDto>(_userRepository.GetById(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }
    }
}
