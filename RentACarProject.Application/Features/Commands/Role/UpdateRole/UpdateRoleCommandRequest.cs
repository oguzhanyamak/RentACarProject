using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Role.UpdateRole
{
    public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
    {
        public string NewName { get; set; }
        public string RoleId { get; set; }
    }
}
