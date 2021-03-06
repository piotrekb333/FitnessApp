﻿using AutoMapper;
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
        public void GetEnabledArticlesTest()
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

        [Fact]
        public void GetEnabledArticleTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ITimeProvider> timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2019, 01, 01));
            var art = new Article
            {
                Id = 1,
                Enabled = true
            };
            var artDto = new ArticleDto
            {
                Id = 1
            };
            Mock < IArticleRepository> articleRepo = new Mock<IArticleRepository>();
            mockMapper.Setup(x => x.Map<ArticleDto>(It.IsAny<Article>()))
            .Returns(artDto);
            articleRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(art);
            IArticleService serviceModel = new ArticleService(mockMapper.Object, articleRepo.Object, timeProvider.Object);
            var result = serviceModel.GetEnabledArticle(1);

            Assert.True(result is ArticleDto);
            Assert.Equal(1,result.Id);

        }
    }
}
