using AutoMapper;
using FitnessApp.Controllers;
using FitnessApp.Services.Implementations;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.Calculator;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitnessAppTests.Controllers
{

    public class NewsletterControllerTests
    {
        [Fact]
        public void PostNewsletterItemTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<INewsletterService> newsletterService = new Mock<INewsletterService>();
            newsletterService.Setup(x => x.SubscribeNewsletter(It.IsAny<SubscribeNewsletterModel>())).Returns(true);

            NewsletterController controller = new NewsletterController(mockMapper.Object, newsletterService.Object);
            var result = controller.Post(new SubscribeNewsletterModel
            {
                Email="abc@wp.pl"
            });
            Assert.IsType<OkResult>(result);
        }
    }
}
