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
    public class ProductControllerTest
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductControllerTest()
        {
            _productRepository = A.Fake<IProductRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void ProductController_GetProducts_ReturnOk()
        {
            //Arrange
            var products = A.Fake<ICollection<Product>>();
            var productsDto = A.Fake<List<ProductDto>>();
            //configure the behavior of the mock of type IMapper
            A.CallTo(() => _mapper.Map<List<ProductDto>>(products)).Returns(productsDto);
            var controller = new ProductController(_productRepository, _mapper);

            //Act
            var result = controller.GetProducts();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }


    }
}
