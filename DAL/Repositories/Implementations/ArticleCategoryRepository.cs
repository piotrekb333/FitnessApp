using DAL.Context;
using DAL.Repositories.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Implementations
{
    public class ArticleCategoryRepository : RepositoryBase<ArticleCategory>, IArticleCategoryRepository
    {
        public ArticleCategoryRepository(WebApiContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
