using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Configuration;
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


            Mock<IArticleCategoryRepository> repository = new Mock<IArticleCategoryRepository>();
            var art = new ArticleCategory { Id = 2, Name = "test" };
            var artDto = new ArticleCategoryDto { Id = 2, Name = "test" };

            var listArt = new List<ArticleCategory>();
            var listArtDto = new List<ArticleCategoryDto>();
            listArtDto.Add(artDto);
            listArt.Add(art);
            
            mockMapper.Setup(x => x.Map<IEnumerable<ArticleCategoryDto>>(It.IsAny<IEnumerable<ArticleCategory>>()))
             .Returns(listArtDto);
             
            repository.Setup(x => x.GetAll()).Returns(listArt);

            IArticleCategoryService serviceModel = new ArticleCategoryService(mockMapper.Object, repository.Object, timeProvider.Object);
            var result = serviceModel.GetAllArticleCategories();

            ArticleCategoryDto cat =result.ToList().FirstOrDefault();
            Assert.True(result is IEnumerable<ArticleCategoryDto>);
            Assert.Equal("test", cat.Name);
        }
    }
}
