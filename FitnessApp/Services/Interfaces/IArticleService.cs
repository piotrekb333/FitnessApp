using Models.ServiceModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<ArticleDto> GetEnabledArticles();
    }
}
