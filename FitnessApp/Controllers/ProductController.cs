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
    [Route("api/product")]
    [EnableCors("MyPolicy")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Post(AddProductModel model)
        {
            var result = _productService.AddProduct(model);
            if (result == ServiceResult.Ok)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(UpdateProductModel model)
        {
            var result = _productService.UpdateProduct(model);
            if (result == ServiceResult.Ok)
                return Ok();
            else if (result == ServiceResult.NotFound)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (result == ServiceResult.Ok)
                return Ok();
            else if (result == ServiceResult.NotFound)
                return NoContent();
            else
                return BadRequest();
        }

        [HttpGet]
        public IActionResult GetProductsGroupsByUserId()
        {
            var userId = User.CurrentUserId();
            var result = _productService.GetProductsGroupsByUserId(userId);
            return Ok(result);
        }
    }
}
