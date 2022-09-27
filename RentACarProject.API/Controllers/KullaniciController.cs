using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Kullanici.CreateKullanici;
using RentACarProject.Application.ViewModel.Kullanici;

namespace RentACarProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediatR;

        public KullaniciController(IMapper mapper, IMediator mediatR)
        {
            _mapper = mapper;
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task<IActionResult> Post(KullaniciEkleVM vM)
        {
            CreateKullaniciCommandRequest request = _mapper.Map<CreateKullaniciCommandRequest>(vM);
            CreateKullaniciCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}
