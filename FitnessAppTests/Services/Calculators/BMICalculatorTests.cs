using FitnessApp.Services.Implementations.Calculators;
using FitnessApp.Services.Interfaces;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FitnessAppTests.Services.Calculators
{
    public class BMICalculatorTests
    {
        [Fact]
        public void CalculateTest()
        {
            ICalculator calculator = new BMICalculator();
            CalculatorModel model = new CalculatorModel();
            model.Age = 1;
            model.Gender = Models.Enums.GenderEnum.Gender.Man;
            model.Height = 1;
            model.Waist = 1;
            model.Weight = 1;
            model.Hip = 1;
            var result=calculator.Calculate(model);
            Assert.True(result.BMIResult > 0);
        }
    }
}
