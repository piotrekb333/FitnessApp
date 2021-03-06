﻿using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Interfaces
{
    public interface ICalculator
    {
        CalculatorResultModel Calculate(CalculatorModel model);
    }
}
