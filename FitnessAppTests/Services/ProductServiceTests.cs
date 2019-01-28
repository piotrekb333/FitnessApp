using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Implementations;
using FitnessApp.Services.Interfaces;
using Models.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitnessAppTests.Services
{
    public class ProductServiceTests
    {
        [Fact]
        public void AddProductTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ITimeProvider> timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2019, 01, 01));
            mockMapper.SetReturnsDefault(new Product());
            Mock<IProductRepository> productRepo = new Mock<IProductRepository>();
            productRepo.Setup(x => x.Create(It.IsAny<Product>()));
            IProductService serviceModel = new ProductService(mockMapper.Object, productRepo.Object, timeProvider.Object);
            var result = serviceModel.AddProduct(new Models.ServiceModels.Product.AddProductModel
            {
               Calories=4
            });

            Assert.True(result == Models.Enums.ResultEnum.ServiceResult.Ok);
        }

        [Fact]
        public void UpdateProductTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ITimeProvider> timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2019, 01, 01));
            mockMapper.SetReturnsDefault(new Product { Id=4,Calories=3});
            var prod = new Product { Id = 4, Calories = 3 };
            Mock<IProductRepository> productRepo = new Mock<IProductRepository>();
            productRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(prod);
            productRepo.Setup(x => x.Update(It.IsAny<Product>()));
            IProductService serviceModel = new ProductService(mockMapper.Object, productRepo.Object, timeProvider.Object);
            var result = serviceModel.UpdateProduct(new Models.ServiceModels.Product.UpdateProductModel
            {
                Calories = 4,
                Id=2
            });

            Assert.True(result == Models.Enums.ResultEnum.ServiceResult.Ok);
        }

        [Fact]
        public void DeleteProductTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ITimeProvider> timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2019, 01, 01));
            mockMapper.SetReturnsDefault(new Product { Id = 4, Calories = 3 });
            var prod = new Product { Id = 4, Calories = 3 };
            Mock<IProductRepository> productRepo = new Mock<IProductRepository>();
            productRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(prod);
            productRepo.Setup(x => x.Delete(It.IsAny<Product>()));
            IProductService serviceModel = new ProductService(mockMapper.Object, productRepo.Object, timeProvider.Object);
            var result = serviceModel.DeleteProduct(2);
            Assert.True(result == Models.Enums.ResultEnum.ServiceResult.Ok);
        }
    }
}
