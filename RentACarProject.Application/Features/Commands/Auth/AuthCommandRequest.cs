using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Auth
{
    public class AuthCommandRequest : IRequest<AuthCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
