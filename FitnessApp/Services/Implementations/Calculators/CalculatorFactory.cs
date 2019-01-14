using FitnessApp.Services.Interfaces;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations.Calculators
{
    public class CalculatorFactory : ICalculatorFactory
    {
        public ICalculator ChooseCalculator(CalculatorEnum.Calculators calculator)
        {
            ICalculator result = null;
            switch (calculator)
            {
                case CalculatorEnum.Calculators.BMI:
                    result = new BMICalculator();
                    break;
                case CalculatorEnum.Calculators.BMR:
                    result = new BMRCalculator();
                    break;
                case CalculatorEnum.Calculators.WHR:
                    result = new WHRCalculator();
                    break;
            }
            return result;
            
        }
    }
}
