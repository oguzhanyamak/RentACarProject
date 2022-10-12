using MediatR;
using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.Abstraction.Token;
using RentACarProject.Application.ViewModel.Token;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Auth
{
    public class AuthCommandRequestHandler : IRequestHandler<AuthCommandRequest, AuthCommandResponse>
    {

        public readonly IAuthService _authService;

        public AuthCommandRequestHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthCommandResponse> Handle(AuthCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.LoginAsync(request.Email, request.Password, 15);
            return new()
            {
                Token = token
            };
        }
    }
}
