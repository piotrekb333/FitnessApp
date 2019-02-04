using Models.ServiceModels.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Interfaces
{
    public interface IArticleCategoryService
    {
        IEnumerable<ArticleCategoryDto> GetAllArticleCategories();
    }
}
