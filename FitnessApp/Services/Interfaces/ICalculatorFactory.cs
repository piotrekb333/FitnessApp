using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Models.Enums.CalculatorEnum;

namespace FitnessApp.Services.Interfaces
{
    public interface ICalculatorFactory
    {
        ICalculator ChooseCalculator(Calculators calculator);
    }
}
