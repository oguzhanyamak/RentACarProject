using MediatR;
using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Role.CreateRole
{
    public class CreateRoleCommandRequestHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        readonly IRoleService _roleService;

        public CreateRoleCommandRequestHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _roleService.CreateRoleAsync(request.RoleName);

            if (result.Succeeded)
            {
                return new()
                {
                    Result = true,
                };
            }
            else
            {
                return new()
                {
                    Result = false,
                };
            };
        }
    }

}
