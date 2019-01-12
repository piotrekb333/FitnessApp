using System;
using System.Collections.Generic;
using System.Text;
using static Models.Enums.GenderEnum;

namespace Models.ServiceModels.Calculator
{
    public class CalculatorModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public double Waist { get; set; }
        public double Hip { get; set; }

    }
}
