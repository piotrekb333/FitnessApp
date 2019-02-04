using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Interfaces;
using Models.ServiceModels.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations
{
    public class ArticleCategoryService : IArticleCategoryService
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IMapper _mapper;
        private readonly ITimeProvider _timeProvider;
        public ArticleCategoryService(IMapper mapper, IArticleCategoryRepository articleCategoryRepository, ITimeProvider timeProvider)
        {
            _mapper = mapper;
            _articleCategoryRepository = articleCategoryRepository;
            _timeProvider = timeProvider;
        }

        public IEnumerable<ArticleCategoryDto> GetAllArticleCategories()
        {
            var categories = _articleCategoryRepository.GetAll();
            IEnumerable<ArticleCategoryDto> categoriesDto = _mapper.Map<IEnumerable<ArticleCategoryDto>>(categories);
            return categoriesDto;
        }
    }
}
