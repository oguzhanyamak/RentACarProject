using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Arac.CreateArac;
using RentACarProject.Application.Features.Commands.Arac.UpdateArac;
using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Application.ViewModel.Arac;
using RentACarProject.Domain.Entites;

namespace RentACarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AracController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;

        public AracController(IAracWriteAsyncRepository aracWriteAsyncRepository, ISubeReadAsyncRepository subeReadAsyncRepository, IMapper mapper, IMediator mediatR)
        {
            _mapper = mapper;
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AracEkleVM parac)
        {
            CreateAracCommandRequest request = _mapper.Map<CreateAracCommandRequest>(parac);
            CreateAracCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AracGuncelleVM guncelleVM)
        {
            UpdateAracCommandRequest request = _mapper.Map<UpdateAracCommandRequest>(guncelleVM);
            UpdateAracCommandResponse response = await _mediatR.Send(request);
            return Ok(response.result);
        }
    }
}
