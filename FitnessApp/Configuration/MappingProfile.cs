using AutoMapper;
using Models.Entities;
using Models.ServiceModels.Article;
using Models.ServiceModels.ArticleCategory;
using Models.ServiceModels.Calculator;
using Models.ServiceModels.Product;
using Models.ServiceModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Newsletter, SubscribeNewsletterModel>();
            CreateMap<SubscribeNewsletterModel, Newsletter>();

            CreateMap<Product, ProductDto>();
            CreateMap<AddProductModel, Product>();
            CreateMap<UpdateProductModel, Product>();

            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDto, Article>();

            CreateMap<ArticleCategory, ArticleCategoryDto>();
            CreateMap<ArticleCategoryDto, ArticleCategory>();
        }
    }
}
