using AutoMapper;
using EcommerceAPI.Controllers;
using EcommerceAPI.Dto;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Test.Controllers
{
    public class UserControllerTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserController _userController;
        public UserControllerTest()
        {
            _userRepository = A.Fake<IUserRepository>();
            _mapper = A.Fake<IMapper>();
            _userController = new UserController(_userRepository, _mapper);
        }

        [Fact]
        public void UserController_GetUsers_ReturnOk()
        {
            var users = A.Fake<ICollection<User>>();
            var usersDto = A.Fake<ICollection<UserDto>>();
            A.CallTo(() => _mapper.Map<ICollection<UserDto>>(users)).Returns(usersDto);

            var result = _userController.GetUsers();

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void UserController_DeleteUser_ReturnNoContent()
        {
            int id = 1;
            var user = A.Fake<User>();
            A.CallTo(() => _userRepository.GetById(id)).Returns(user);
            A.CallTo(() => _userRepository.DeleteUser(id)).Returns(true);

            var result = _userController.DeleteUser(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();
        }

    }
}
