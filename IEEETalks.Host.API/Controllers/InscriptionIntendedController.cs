using System.Web.Http;
using AutoMapper;
using IEEETalks.Core.Entities;
using IEEETalks.Host.API.Models;
using IEEETalks.CQRS.Commands;
using MediatR;

namespace IEEETalks.Host.API.Controllers
{
    public class InscriptionIntendedControllerProfile : Profile
    {
        public InscriptionIntendedControllerProfile()
        {
            CreateMap<InscriptionIntendedRequest, InscriptionIntended>();
        }
    }

    public class InscriptionIntendedController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InscriptionIntendedController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // POST: api/InscriptionIntended
        [HttpPost]
        public IHttpActionResult Post(InscriptionIntendedRequest request)
        {
            var inscriptionIntended = _mapper.Map<InscriptionIntendedRequest, InscriptionIntended>(request);

            _mediator.Send(new SaveInscriptionIntended(inscriptionIntended));

            return Ok();
        }
    }
}
