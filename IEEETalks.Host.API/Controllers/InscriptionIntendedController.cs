using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using IEEETalks.Common.IoC;
using IEEETalks.Core.Entities;
using IEEETalks.Data.Repositories.Interfaces;
using IEEETalks.Host.API.Models;

namespace IEEETalks.Host.API.Controllers
{
    public class InscriptionIntendedController : ApiController
    {
        private readonly IInscriptionIntended _inscriptionIntendedRepository;
        private readonly IMapper _mapper;

        public InscriptionIntendedController()
        {
           _inscriptionIntendedRepository = Container.Current.Resolve<IInscriptionIntended>();
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InscriptionIntendedDto, InscriptionIntended>();
            });

            _mapper = mapperConfiguration.CreateMapper();

        }

        public void Post(InscriptionIntendedDto request)
        {
            var domainInscriptionIntended = _mapper.Map<InscriptionIntendedDto, InscriptionIntended>(request);

            _inscriptionIntendedRepository.Store(domainInscriptionIntended);
        }

    }
}
