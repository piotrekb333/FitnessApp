using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Interfaces
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
        string ToShortDateString();
    }
}
