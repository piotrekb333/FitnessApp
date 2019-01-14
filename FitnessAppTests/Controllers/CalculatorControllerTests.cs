using AutoMapper;
using FitnessApp.Controllers;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.ServiceModels.Calculator;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitnessAppTests.Controllers
{
    public class CalculatorControllerTests
    {
        [Fact]
        public void BmiTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ICalculatorFactory> calculatorFactory = new Mock<ICalculatorFactory>();
            Mock<ICalculator> calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Calculate(It.IsAny<CalculatorModel>())).Returns(new CalculatorResultModel());
            calculatorFactory.Setup(x => x.ChooseCalculator(It.IsAny<CalculatorEnum.Calculators>())).Returns(calculator.Object);

            CalculatorController controller = new CalculatorController(mockMapper.Object, calculatorFactory.Object);
            var result=controller.Bmi(new Models.ServiceModels.Calculator.CalculatorModel
            {
                Age=15,
                Gender=Models.Enums.GenderEnum.Gender.Man,
                Height=1,
                Hip=1,
                Waist=1,
                Weight=1
            });
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void BmrTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ICalculatorFactory> calculatorFactory = new Mock<ICalculatorFactory>();
            Mock<ICalculator> calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Calculate(It.IsAny<CalculatorModel>())).Returns(new CalculatorResultModel());
            calculatorFactory.Setup(x => x.ChooseCalculator(It.IsAny<CalculatorEnum.Calculators>())).Returns(calculator.Object);

            CalculatorController controller = new CalculatorController(mockMapper.Object, calculatorFactory.Object);
            var result = controller.Bmr(new Models.ServiceModels.Calculator.CalculatorModel
            {
                Age = 15,
                Gender = Models.Enums.GenderEnum.Gender.Man,
                Height = 1,
                Hip = 1,
                Waist = 1,
                Weight = 1
            });
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void WhrTest()
        {
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            Mock<ICalculatorFactory> calculatorFactory = new Mock<ICalculatorFactory>();
            Mock<ICalculator> calculator = new Mock<ICalculator>();
            calculator.Setup(x => x.Calculate(It.IsAny<CalculatorModel>())).Returns(new CalculatorResultModel());
            calculatorFactory.Setup(x => x.ChooseCalculator(It.IsAny<CalculatorEnum.Calculators>())).Returns(calculator.Object);

            CalculatorController controller = new CalculatorController(mockMapper.Object, calculatorFactory.Object);
            var result = controller.Whr(new Models.ServiceModels.Calculator.CalculatorModel
            {
                Age = 15,
                Gender = Models.Enums.GenderEnum.Gender.Man,
                Height = 1,
                Hip = 1,
                Waist = 1,
                Weight = 1
            });
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
