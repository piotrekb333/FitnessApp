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
        private readonly IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
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
