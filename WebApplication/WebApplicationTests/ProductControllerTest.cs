using WebApplication.Controllers;
using WebApplication.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTests
{
    public class ProductControllerTest
    {
        [Fact]
        public void GetProductByIdTest()
        {
            // Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.Products).Returns(new Product[] {
                new Product { ProductID = 1, Name = "Product 1"},
                new Product { ProductID = 2, Name = "Product 2"},
                new Product { ProductID = 3, Name = "Product 3"}

            }.AsQueryable<Product>());

            var controller = new ProductController(productRepositoryMock.Object);

            // Act
            var result = controller.GetById(2);
            Product product = result.ViewData.Model as Product;

            // Assert
            Assert.Equal("Product 2", product.Name);
        }

        [Theory]
        [InlineData(1, "Product 1")]
        [InlineData(2, "Product 2")]
        [InlineData(3, "Product 3")]
        public void GetProductById2Test(int productID, string name)
        {
            // Arrange
            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(x => x.Products).Returns(new Product[] {
                new Product { ProductID = 1, Name = "Product 1"},
                new Product { ProductID = 2, Name = "Product 2"},
                new Product { ProductID = 3, Name = "Product 3"},
                new Product { ProductID = 4, Name = "Product 4"},
                new Product { ProductID = 5, Name = "Product 5"}

            }.AsQueryable<Product>());

            ProductController controller = new ProductController(productRepositoryMock.Object);

            // Act
            ViewResult result = controller.GetById(productID);
            Product product = result.ViewData.Model as Product;

            // Assert
            Assert.Equal(name, product.Name);
        }

    }
}
