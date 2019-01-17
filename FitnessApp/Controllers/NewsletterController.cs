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
    [Route("api/newsletter")]
    [EnableCors("MyPolicy")]
    public class NewsletterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly INewsletterService _newsletterService;
        public NewsletterController(IMapper mapper, INewsletterService newsletterService)
        {
            _mapper = mapper;
            _newsletterService = newsletterService;
        }

        [HttpPost]
        public IActionResult PostNewsletterItem(SubscribeNewsletterModel model)
        {
            var result=_newsletterService.SubscribeNewsletter(model);
            if (result)
                return Ok();
            else
                return BadRequest();

        }
    }
}
