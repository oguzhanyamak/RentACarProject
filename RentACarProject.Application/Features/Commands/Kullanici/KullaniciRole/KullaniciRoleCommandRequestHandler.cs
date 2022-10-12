using MediatR;
using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.KullaniciRole
{
    public class KullaniciRoleCommandRequestHandler : IRequestHandler<KullaniciRoleCommandRequest, KullaniciRoleCommandResponse>
    {
        private readonly IUserService _userService;

        public KullaniciRoleCommandRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<KullaniciRoleCommandResponse> Handle(KullaniciRoleCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userService.AddRoleAsync(request);
            if (result.Succeeded)
            {
                return new()
                {
                    Res = true
                };
            }
            else
            {
                return new()
                {
                    Res = false
                };
            }
        }
    }
}
