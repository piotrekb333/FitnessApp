using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Implementations;
using FitnessApp.Services.Interfaces;
using Models.Entities;
using Models.ServiceModels.Article;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace FitnessAppTests.Services
{
    public class ArticleServiceTests
    {
        [Fact]
        public void SubscribeNewsletterTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ITimeProvider> timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2019, 01, 01));
            mockMapper.SetReturnsDefault(new Newsletter());
            Mock<IArticleRepository> articleRepo = new Mock<IArticleRepository>();
            List<Article> articleList = new List<Article>();
            articleList.Add(new Article
            {
                Id = 1,
                Enabled = true
            });
            articleRepo.Setup(x => x.GetByCondition(It.IsAny<Expression<Func<Article, bool>>>())).Returns(articleList);
            IArticleService serviceModel = new ArticleService(mockMapper.Object, articleRepo.Object, timeProvider.Object);
            var result = serviceModel.GetEnabledArticles();

            Assert.True(result is IEnumerable<ArticleDto>);
        }
    }
}
