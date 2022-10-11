using AutoMapper;
using Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Sube.CreateSube;
using RentACarProject.Application.Features.Commands.Sube.UpdateSube;
using RentACarProject.Application.Features.Queries.Sube.GetAll;
using RentACarProject.Application.Features.Queries.Sube.GetAracs;
using RentACarProject.Application.Features.Queries.Sube.GetById;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Application.ViewModel.Sube;
using RentACarProject.Domain.Entites;

namespace RentACarProject.API.Controllers
{

    [ApiController]
    public class SubeController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubeController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        [Route("Subeler")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubeEkleVM subeEkleVM)
        {
            CreateSubeCommandRequest commandRequest = _mapper.Map<CreateSubeCommandRequest>(subeEkleVM);
            CreateSubeCommandResponse response = await _mediator.Send(commandRequest);
            if (response.result == true)
            {
                return Created($"/Sube/{response.retUrl}",null);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("Subeler")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] SubeGuncelleVM subeGuncelleVM)
        {
            UpdateSubeCommandRequest updateSube = _mapper.Map<UpdateSubeCommandRequest>(subeGuncelleVM);
            UpdateSubeCommandResponse response = await _mediator.Send(updateSube);

            return Ok(response);
        }
        [Route("Subeler")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllSubeQueryRequest queryRequest = new();
            GetAllSubeQueryResponse response = await _mediator.Send(queryRequest);
            return Ok(response);
        }

        [Route("Subeler/{SubeId}")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid SubeId)
        {
            GetSubeByIdQueryRequest getByIdSube = new() { SubeId = SubeId };
            GetSubeByIdQueryResponse response = await _mediator.Send(getByIdSube);
            return Ok(response);

        }
        [Route("Subeler/{SubeId}/Araclar")]
        [HttpGet]
        public async Task<IActionResult> GetAraclar(Guid SubeId)
        {
            GetAracsQueryRequest queryRequest = new() { SubeId = SubeId };
            GetAracsQueryResponse queryResponse = await _mediator.Send(queryRequest);
            return Ok(queryResponse);
        }
    }
}
