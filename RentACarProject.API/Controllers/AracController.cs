using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentACarProject.Application.Features.Commands.Arac.CreateArac;
using RentACarProject.Application.Features.Commands.Arac.DeleteArac;
using RentACarProject.Application.Features.Commands.Arac.UpdateArac;
using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Application.ViewModel.Arac;
using RentACarProject.Domain.Entites;
using System.Net;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RentACarProject.API.Controllers
{

    [ApiController]
    public class AracController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private readonly IAracReadRepositoy _aracReadRepositoy;
        private readonly IMapper _mapper;

        public AracController(IAracWriteAsyncRepository aracWriteAsyncRepository, ISubeReadAsyncRepository subeReadAsyncRepository, IMapper mapper, IMediator mediatR, IAracReadRepositoy aracReadRepositoy)
        {
            _mapper = mapper;
            _mediatR = mediatR;
            _aracReadRepositoy = aracReadRepositoy;
        }
        [Route("Araclar")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AracEkleVM parac)
        {
            CreateAracCommandRequest request = _mapper.Map<CreateAracCommandRequest>(parac);
            CreateAracCommandResponse response = await _mediatR.Send(request);
            if (response.result == true)
                return Created($"Araclar/{response.objectId}", null);
            else
                return BadRequest();
        }
        [Route("Araclar")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AracGuncelleVM guncelleVM)
        {
            UpdateAracCommandRequest request = _mapper.Map<UpdateAracCommandRequest>(guncelleVM);
            UpdateAracCommandResponse response = await _mediatR.Send(request);
            if (response.result == true)
            {
                return Created($"Araclar/{response.objectId}", null);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("Araclar/{AracId}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid AracId)
        {
            DeleteAracCommandRequest deleteRequest = new() { AracId = AracId };
            DeleteAracCommandResponse deleteResponse = await _mediatR.Send(deleteRequest);
            if(deleteResponse.Result == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
