using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarProject.Application.Features.Commands.Role.CreateRole;
using RentACarProject.Application.Features.Commands.Role.UpdateRole;
using RentACarProject.Application.Features.Queries.Role.GetAll;
using RentACarProject.Application.ViewModel.Role;

namespace RentACarProject.API.Controllers
{
    [Authorize(Roles = "Admin,TeknikEkip")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IMediator _mediatR;
        private readonly IMapper _mapper;

        public RoleController(IMediator mediatR, IMapper mapper)
        {
            _mediatR = mediatR;
            _mapper = mapper;
        }

        [Route("/Role")]
        [HttpPost]
        public async Task<IActionResult> RoleEkle(string RoleName)
        {
            CreateRoleCommandRequest request = new CreateRoleCommandRequest() { RoleName = RoleName };
            CreateRoleCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }

        [Route("/Role")]
        [HttpPut]
        public async Task<IActionResult> put(RoleUpdateVM model)
        {
            UpdateRoleCommandRequest request = _mapper.Map<UpdateRoleCommandRequest>(model);
            UpdateRoleCommandResponse response = await _mediatR.Send(request);
            return Ok(response);
        }


        [Route("/Role")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllRolesQueryRequest request = new();
            GetAllRolesQueryResponse response = await _mediatR.Send(request);
            return Ok(response);
        }
    }
}
