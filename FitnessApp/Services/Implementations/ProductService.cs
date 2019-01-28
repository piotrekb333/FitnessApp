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
        private readonly ITimeProvider _timeProvider;

        public ProductService(IMapper mapper, IProductRepository productRepository, ITimeProvider timeProvider)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _timeProvider = timeProvider;
        }

        public ServiceResult AddProduct(AddProductModel model)
        {
            Product productModel = _mapper.Map<Product>(model);
            productModel.DateCreated = _timeProvider.UtcNow;
            if (productModel.DateUser == null)
                productModel.DateUser = _timeProvider.UtcNow;
            return ServiceResult.Ok;
        }

        public ServiceResult UpdateProduct(UpdateProductModel model)
        {
            var product = _productRepository.GetById(model.Id);
            if (product == null)
                return ServiceResult.NotFound;
            Product productModel = _mapper.Map<UpdateProductModel, Product>(model, product);
            productModel.DateModified = _timeProvider.UtcNow;
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

        public IEnumerable<ProductModel> GetProductsByUserId(int userId)
        {
            var products = _productRepository.GetByCondition(m => m.UserId == userId);
            IEnumerable<ProductDto> productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productsDto;
        }

        public IEnumerable<ProductGroupsDto> GetProductsGroupsByUserId(int userId)
        {
            var products = _productRepository.GetByCondition(m => m.UserId == userId);
            var productsGroup = products
                .GroupBy(m => new { m.DateUser.Value.Year, m.DateUser.Value.Month, m.DateUser.Value.Day })
                .Select(m => new ProductGroupsDto { Date = new DateTime(m.Key.Year, m.Key.Month, m.Key.Day), Products = _mapper.Map<IEnumerable<ProductDto>>(m).OrderBy(z=>z.DateUser) });
            return productsGroup;
        }
    }
}
