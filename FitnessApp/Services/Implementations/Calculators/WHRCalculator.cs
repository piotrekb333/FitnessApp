using FitnessApp.Services.Interfaces;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations.Calculators
{
    public class WHRCalculator : ICalculator
    {
        public CalculatorResultModel Calculate(CalculatorModel model)
        {
            CalculatorResultModel result = new CalculatorResultModel();
            result.WHRResult = model.Waist / model.Hip;
            return result;
        }
    }
}
