using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Models.Enums.ResultEnum;

namespace FitnessApp.Services.Interfaces
{
    public interface INewsletterService
    {
        ServiceResult SubscribeNewsletter(SubscribeNewsletterModel model);
    }
}
