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
            Mock<INewsletterService> newsletterService = new Mock<INewsletterService>();
            newsletterService.Setup(x => x.SubscribeNewsletter(It.IsAny<SubscribeNewsletterModel>())).Returns(Models.Enums.ResultEnum.ServiceResult.Ok);

            NewsletterController controller = new NewsletterController(newsletterService.Object);
            var result = controller.Post(new SubscribeNewsletterModel
            {
                Email="abc@wp.pl"
            });
            Assert.IsType<OkResult>(result);
        }
    }
}
