using RentACarProject.Application.ViewModel.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Auth
{
    public class AuthCommandResponse
    {
        public Token Token { get; set; }
    }
}
