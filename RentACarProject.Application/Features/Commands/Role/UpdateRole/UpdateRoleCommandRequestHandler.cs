using MediatR;
using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleCommandRequestHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        private readonly IRoleService _roleService;

        public UpdateRoleCommandRequestHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result =  await _roleService.UpdateRoleAsync(request);
            if (result.Succeeded)
            {
                return new()
                {
                    result = true
                };
            }
            else
            {
                return new()
                {
                    result = false
                };
            }
        }
    }
}
