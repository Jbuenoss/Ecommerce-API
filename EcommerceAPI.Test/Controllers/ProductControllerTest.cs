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
        private readonly ProductController _controller;
        public ProductControllerTest()
        {
            _productRepository = A.Fake<IProductRepository>();
            _mapper = A.Fake<IMapper>();
            _controller = new ProductController(_productRepository, _mapper);
        }

        [Fact]
        public void ProductController_GetProducts_ReturnOk()
        {
            //Arrange
            var products = A.Fake<ICollection<Product>>();
            var productsDto = A.Fake<List<ProductDto>>();
                //configure the behavior of the mock of type IMapper
            A.CallTo(() => _mapper.Map<List<ProductDto>>(products)).Returns(productsDto);

            //Act
            var result = _controller.GetProducts();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ProductController_GetProduct_ReturnOk()
        {
            int idProduct = 1;
            var product = A.Fake<Product>();
            var productDto = A.Fake<ProductDto>();
            A.CallTo(() => _productRepository.GetProduct(idProduct)).Returns(product);
            A.CallTo(() => _mapper.Map<ProductDto>(product)).Returns(productDto);

            var result = _controller.GetProduct(idProduct);


            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ProductController_CreateProduct_ReturnOk()
        {
            Product product = A.Fake<Product>();
            int userId = 1;
            A.CallTo(() => _productRepository.CreateProduct(product, userId)).Returns(true);
            A.CallTo(() => _productRepository.CheckUser(userId)).Returns(true);

            var result = _controller.CreateProduct(product, userId);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        

    }
}
