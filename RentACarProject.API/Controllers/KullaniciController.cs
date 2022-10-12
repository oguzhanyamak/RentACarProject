using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Kullanici.CreateKullanici;
using RentACarProject.Application.Features.Commands.Kullanici.KullaniciRole;
using RentACarProject.Application.Features.Commands.Kullanici.UpdateKullanici;
using RentACarProject.Application.Features.Commands.Kullanici.UpdatePassword;
using RentACarProject.Application.ViewModel.Kullanici;
using System.Data;

namespace RentACarProject.API.Controllers
{
    [Authorize(Roles = "Admin,TeknikEkip")]
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
        [AllowAnonymous]
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

        [Route("Kullanicilar/SifreGuncelle")]
        [HttpPut]
        public async Task<IActionResult> put(string email,string oldPassword,string newPassword)
        {
            UpdatePasswordQueryRequest request = new UpdatePasswordQueryRequest() { email = email, newPassword = newPassword, oldPassword = oldPassword };
            UpdatePasswordQueryResponse response = await _mediatR.Send(request);
            return Ok(response);
        }

        [Route("Kullanicilar/RolAta")]
        [HttpPut]
        public async Task<IActionResult> UserRole(KullaniciRoleVM model)
        {
            KullaniciRoleCommandRequest request = _mapper.Map<KullaniciRoleCommandRequest>(model);
            KullaniciRoleCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }

    }
}
