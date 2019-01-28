using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Interfaces;
using Models.ServiceModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        private readonly ITimeProvider _timeProvider;

        public ArticleService(IMapper mapper, IArticleRepository articleRepository, ITimeProvider timeProvider)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _timeProvider = timeProvider;
        }

        public IEnumerable<ArticleDto> GetEnabledArticles()
        {
            var articles = _articleRepository.GetByCondition(m => m.Enabled).OrderByDescending(m => m.DateCreated);
            IEnumerable<ArticleDto> articlesDto = _mapper.Map<IEnumerable<ArticleDto>>(articles);
            return articlesDto;
        }
    }
}
