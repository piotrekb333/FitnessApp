using FitnessApp.Services.Interfaces;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations.Calculators
{
    public class BMICalculator : ICalculator
    {
        public CalculatorResultModel Calculate(CalculatorModel model)
        {
            CalculatorResultModel resultModel = new CalculatorResultModel();
            double heightParse = model.Height / 100d;
            resultModel.BMIResult = model.Weight / Math.Pow(heightParse, 2);
            return resultModel;
        }
    }
}
