using System.Web.Http;
using AutoMapper;
using IEEETalks.Common.IoC;
using IEEETalks.Core.Entities;
using IEEETalks.CQS.Infrastructure.CommandProcessor;
using IEEETalks.CQS.Infrastructure.Commands;
using IEEETalks.Host.API.Models;

namespace IEEETalks.Host.API.Controllers
{
    public class InscriptionIntendedController : ApiController
    {
        private readonly ICommandBus _commandBus;
        private readonly IMapper _mapper;

        public InscriptionIntendedController()
        {
            _commandBus = Container.Current.Resolve<ICommandBus>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InscriptionIntendedDto, InscriptionIntended>();
            });

            _mapper = mapperConfiguration.CreateMapper();

        }

        // POST: api/InscriptionIntended
        public void Post(InscriptionIntendedDto request)
        {
            var inscriptionIntended = _mapper.Map<InscriptionIntendedDto, InscriptionIntended>(request);

            var command = new SaveInscriptionIntended(inscriptionIntended);

            var result = _commandBus.Submit(command);

            this.ValidateCommandResult(result);
        }
    }
}
