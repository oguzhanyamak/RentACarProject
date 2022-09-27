using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Sube.CreateSube;
using RentACarProject.Application.Features.Commands.Sube.UpdateSube;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Application.ViewModel.Sube;
using RentACarProject.Domain.Entites;

namespace RentACarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubeController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubeController( IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubeEkleVM subeEkleVM)
        {
            CreateSubeCommandRequest commandRequest = _mapper.Map<CreateSubeCommandRequest>(subeEkleVM);
            CreateSubeCommandResponse createSubeCommandResponse = await _mediator.Send(commandRequest);
            return Ok(createSubeCommandResponse.result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SubeGuncelleVM subeGuncelleVM)
        {
            UpdateSubeCommandRequest updateSube = _mapper.Map<UpdateSubeCommandRequest>(subeGuncelleVM);
            UpdateSubeCommandResponse response = await _mediator.Send(updateSube);
            return Ok(response);
        }

    }
}
