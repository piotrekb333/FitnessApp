using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Interfaces;
using Models.Entities;
using Models.ServiceModels.Product;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Models.Enums.ResultEnum;

namespace FitnessApp.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public ServiceResult AddProduct(AddProductModel model)
        {
            Product productModel = _mapper.Map<Product>(model);
            productModel.DateCreated = DateTime.UtcNow;
            return ServiceResult.Ok;
        }
        public ServiceResult UpdateProduct(UpdateProductModel model)
        {
            var product = _productRepository.GetById(model.Id);
            if (product == null)
                return ServiceResult.NotFound;
            Product productModel = _mapper.Map<UpdateProductModel, Product>(model, product);
            productModel.DateModified = DateTime.UtcNow;
            _productRepository.Update(productModel);
            return ServiceResult.Ok;
        }
        public ServiceResult DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
                return ServiceResult.NotFound;
            _productRepository.Delete(product);
            return ServiceResult.Ok;
        }

        public IEnumerable<ProductModel> GetProductsByUser(int userId)
        {
            var products=_productRepository.GetByCondition(m => m.UserId == userId);
            IEnumerable<ProductDto> productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }
    }
}
