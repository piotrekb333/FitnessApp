using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Interfaces;
using Models.Entities;
using Models.Enums;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Models.Enums.ResultEnum;

namespace FitnessApp.Services.Implementations
{
    public class NewsletterService : INewsletterService
    {
        private readonly INewsletterRepository _newsletterRepository;
        private readonly IMapper _mapper;
        private readonly ITimeProvider _timeProvider;
        public NewsletterService(IMapper mapper, INewsletterRepository newsletterRepository, ITimeProvider timeProvider)
        {
            _mapper = mapper;
            _newsletterRepository = newsletterRepository;
            _timeProvider = timeProvider;
        }

        public ServiceResult SubscribeNewsletter(SubscribeNewsletterModel model)
        {
            Newsletter newsletterModel = _mapper.Map<Newsletter>(model);
            newsletterModel.DateCreated = _timeProvider.UtcNow;
            _newsletterRepository.Create(newsletterModel);
            return ServiceResult.Ok;
        }
    }
}
