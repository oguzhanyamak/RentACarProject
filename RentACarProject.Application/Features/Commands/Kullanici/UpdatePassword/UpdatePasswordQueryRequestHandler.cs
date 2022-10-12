using MediatR;
using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.UpdatePassword
{
    public class UpdatePasswordQueryRequestHandler : IRequestHandler<UpdatePasswordQueryRequest, UpdatePasswordQueryResponse>
    {
        private readonly IUserService _userService;

        public UpdatePasswordQueryRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdatePasswordQueryResponse> Handle(UpdatePasswordQueryRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userService.ChangePassword(request.email, request.oldPassword, request.newPassword);
            if (!result.Succeeded)
            {
                string message = "";
                foreach (var error in result.Errors)
                    message += $"{error.Description} - {error.Code} \n";
                return new()
                {
                   message = message,
                   result = false
                };
            }
            return new()
            {
                result = true,
            };
        }
    }
}
