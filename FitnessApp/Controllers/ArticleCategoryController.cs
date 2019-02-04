using AutoMapper;
using FitnessApp.Helpers;
using FitnessApp.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Models.Enums.ResultEnum;

namespace FitnessApp.Controllers
{
    [Produces("application/json")]
    [Route("api/articleCategory")]
    [EnableCors("MyPolicy")]
    public class ArticleCategoryController : Controller
    {
        private readonly IArticleCategoryService _articleCategoryService;
        public ArticleCategoryController(IArticleCategoryService articleCategoryService)
        {
            _articleCategoryService = articleCategoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _articleCategoryService.GetAllArticleCategories();
            return Ok(result);
        }
    }
}
