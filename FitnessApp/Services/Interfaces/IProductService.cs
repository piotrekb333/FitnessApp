using Models.ServiceModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Models.Enums.ResultEnum;

namespace FitnessApp.Services.Interfaces
{
    public interface IProductService
    {
        ServiceResult AddProduct(AddProductModel model);
        ServiceResult UpdateProduct(UpdateProductModel model);
        ServiceResult DeleteProduct(int id);
        IEnumerable<ProductDto> GetProductsByUserId(int userId);
        IEnumerable<ProductGroupsDto> GetProductsGroupsByUserId(int userId);
    }
}
