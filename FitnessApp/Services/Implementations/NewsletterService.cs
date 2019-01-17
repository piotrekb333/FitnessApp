using AutoMapper;
using DAL.Repositories.Interfaces;
using FitnessApp.Services.Interfaces;
using Models.Entities;
using Models.ServiceModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations
{
    public class NewsletterService : INewsletterService
    {
        private readonly INewsletterRepository _newsletterRepository;
        private readonly IMapper _mapper;
        public NewsletterService(IMapper mapper, INewsletterRepository newsletterRepository)
        {
            _mapper = mapper;
            _newsletterRepository = newsletterRepository;
        }

        public bool SubscribeNewsletter(SubscribeNewsletterModel model)
        {
            Newsletter newsletterModel = _mapper.Map<Newsletter>(model);
            newsletterModel.DateCreated = DateTime.UtcNow;
            _newsletterRepository.Create(newsletterModel);
            return true;
        }
    }
}
