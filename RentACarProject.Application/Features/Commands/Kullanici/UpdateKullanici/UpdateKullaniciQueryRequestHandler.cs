using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.ViewModel.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.UpdateKullanici
{
    public class UpdateKullaniciQueryRequestHandler : IRequestHandler<UpdateKullaniciQueryRequest, UpdateKullaniciQueryResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UpdateKullaniciQueryRequestHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdateKullaniciQueryResponse> Handle(UpdateKullaniciQueryRequest request, CancellationToken cancellationToken)
        {
            IdentityResult res = await _userService.UpdateAsync(request);
            if (res.Succeeded)
            {
                return new()
                {
                    res = true,
                };
            }
            else
            {
                string message = "";
                foreach (var error in res.Errors)
                    message += $"{error.Code} - {error.Description}";

                return new()
                {
                    res = message
                };
            }

        }
    }
}
