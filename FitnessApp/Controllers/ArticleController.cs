using AutoMapper;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Controllers
{
    [Produces("application/json")]
    [Route("api/article")]
    [EnableCors("MyPolicy")]
    public class ArticleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        public ArticleController(IMapper mapper, IArticleService articleService)
        {
            _mapper = mapper;
            _articleService = articleService;
        }

        [HttpGet("enabledArticles")]
        public IActionResult EnabledArticles()
        {
            var result = _articleService.GetEnabledArticles();
            return Ok(result);
        }
    }
}
