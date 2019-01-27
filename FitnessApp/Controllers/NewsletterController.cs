using AutoMapper;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.Calculator;
using static Models.Enums.ResultEnum;

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
        public IActionResult Post(SubscribeNewsletterModel model)
        {
            var result=_newsletterService.SubscribeNewsletter(model);
            if (result==ServiceResult.Ok)
                return Ok();
            else
                return BadRequest();

        }
    }
}
