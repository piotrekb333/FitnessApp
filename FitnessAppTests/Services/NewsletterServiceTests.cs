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
    public class NewsletterServiceTests
    {
        [Fact]
        public void SubscribeNewsletterTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ITimeProvider> timeProvider = new Mock<ITimeProvider>();
            timeProvider.Setup(m => m.UtcNow).Returns(new DateTime(2019, 01, 01));
            mockMapper.SetReturnsDefault(new Newsletter());
            Mock<INewsletterRepository> newsletterRepository = new Mock<INewsletterRepository>();
            newsletterRepository.Setup(x => x.Create(It.IsAny<Newsletter>()));
            INewsletterService serviceModel = new NewsletterService(mockMapper.Object,newsletterRepository.Object, timeProvider.Object);
            var result = serviceModel.SubscribeNewsletter(new Models.ServiceModels.Calculator.SubscribeNewsletterModel
            {
                Email = "abc@wp.pl"
            });

            Assert.True(result==Models.Enums.ResultEnum.ServiceResult.Ok);
        }
    }
}
