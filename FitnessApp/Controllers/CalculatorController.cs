using AutoMapper;
using FitnessApp.Services.Implementations.Calculators;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Controllers
{
    [Produces("application/json")]
    [Route("api/calculator")]
    [EnableCors("MyPolicy")]
    public class CalculatorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICalculatorFactory _calculatorFactory;
        public CalculatorController(IMapper mapper, ICalculatorFactory calculatorFactory)
        {
            _mapper = mapper;
            _calculatorFactory = calculatorFactory;
        }


        [HttpGet("bmi")]
        public IActionResult Bmi(CalculatorModel model)
        {
            ICalculator calculator = _calculatorFactory.ChooseCalculator(Models.Enums.CalculatorEnum.Calculators.BMI);
            var result=calculator.Calculate(model);
            return Ok(result);
        }

        [HttpGet("bmr")]
        public IActionResult Bmr(CalculatorModel model)
        {
            ICalculator calculator = _calculatorFactory.ChooseCalculator(Models.Enums.CalculatorEnum.Calculators.BMR);
            var result = calculator.Calculate(model);
            return Ok(result);
        }

        [HttpGet("whr")]
        public IActionResult Whr(CalculatorModel model)
        {
            ICalculator calculator = _calculatorFactory.ChooseCalculator(Models.Enums.CalculatorEnum.Calculators.WHR);
            var result = calculator.Calculate(model);
            return Ok(result);
        }
    }
}
