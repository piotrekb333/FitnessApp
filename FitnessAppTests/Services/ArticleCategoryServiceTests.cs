using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Implementations;
using FitnessApp.Services.Interfaces;
using Models.Entities;
using Models.ServiceModels.Article;
using Models.ServiceModels.ArticleCategory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace FitnessAppTests.Services
{
    public class ArticleCategoryServiceTests
    {
        [Fact]
        public void GetAllArticleCategoriesTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ITimeProvider> timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2019, 01, 01));
            mockMapper.SetReturnsDefault(new List<ArticleCategoryDto>());
            Mock<IArticleCategoryRepository> repository = new Mock<IArticleCategoryRepository>();
            repository.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<ArticleCategory, bool>>>())).Returns(new List<ArticleCategory>() { new ArticleCategory { Id=2,Name="test"} });
            IArticleCategoryService serviceModel = new ArticleCategoryService(mockMapper.Object, repository.Object, timeProvider.Object);
            var result = serviceModel.GetAllArticleCategories();

            ArticleCategoryDto cat =result.ToList().FirstOrDefault();
            Assert.True(result is IEnumerable<ArticleCategoryDto>);
            Assert.Equal("test", cat.Name);
        }
    }
}
