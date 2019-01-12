using FitnessApp.Services.Interfaces;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations.Calculators
{
    public class BMRCalculator : ICalculator
    {
        public CalculatorResultModel Calculate(CalculatorModel model)
        {
            CalculatorResultModel result = new CalculatorResultModel();
            if (model.Gender == Models.Enums.GenderEnum.Gender.Man)
            {
                result.BMRResult = 66.47d + (13.75d * model.Weight) + (5.003d * model.Height) + (6.755d * model.Age);
            }
            if (model.Gender == Models.Enums.GenderEnum.Gender.Women)
            {
                result.BMRResult = 655.1d + (9.563d * model.Weight) + (1.85d * model.Height) + (4.676d * model.Age);
            }
            return result;
        }
    }
}
