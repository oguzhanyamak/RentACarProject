using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Kullanici.CreateKullanici;
using RentACarProject.Application.Features.Commands.Kullanici.UpdateKullanici;
using RentACarProject.Application.ViewModel.Kullanici;

namespace RentACarProject.API.Controllers
{
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
        [Route("Kullanicilar")]
        [HttpPost]
        public async Task<IActionResult> Post(KullaniciEkleVM vM)
        {
            CreateKullaniciCommandRequest request = _mapper.Map<CreateKullaniciCommandRequest>(vM);
            CreateKullaniciCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }

        [Route("Kullanicilar")]
        [HttpPut]
        public async Task<IActionResult> Put(KullaniciGuncelleVM vm)
        {
            UpdateKullaniciQueryRequest request = _mapper.Map<UpdateKullaniciQueryRequest>(vm);
            UpdateKullaniciQueryResponse response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}
