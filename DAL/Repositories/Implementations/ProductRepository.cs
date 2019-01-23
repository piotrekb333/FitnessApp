using DAL.Context;
using DAL.Repositories.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Implementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
