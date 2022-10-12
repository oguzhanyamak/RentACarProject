using MediatR;
using RentACarProject.Application.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Role.GetAll
{
    public class GetAllRolesQueryRequestHandler : IRequestHandler<GetAllRolesQueryRequest, GetAllRolesQueryResponse>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryRequestHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetAllRolesQueryResponse> Handle(GetAllRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = _roleService.GetAllRoles();
            return new()
            {
                RoleList = roles
            };
        }
    }
}
