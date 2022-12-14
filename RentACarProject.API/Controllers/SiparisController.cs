using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Siparis.Create;
using RentACarProject.Application.ViewModel.Siparis;

namespace RentACarProject.API.Controllers
{
    [Authorize(Roles = "Admin,TeknikEkip")]
    [Route("Siparisler")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;
        public SiparisController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SiparisVerVM siparisVerVM)
        {
            CreateSiparisCommandRequest createSiparisCommandRequest = _mapper.Map<CreateSiparisCommandRequest>(siparisVerVM);
            CreateSiparisCommandResponse response = await _mediator.Send(createSiparisCommandRequest);
            return Ok(response);
        }
    }
}
