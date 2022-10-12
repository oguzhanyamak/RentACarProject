using AutoMapper;
using MediatR;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.ViewModel.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.CreateKullanici
{
    public class CreateKullaniciCommandHandler : IRequestHandler<CreateKullaniciCommandRequest, CreateKullaniciCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public CreateKullaniciCommandHandler(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        public async Task<CreateKullaniciCommandResponse> Handle(CreateKullaniciCommandRequest request, CancellationToken cancellationToken)
        {
            KullaniciEkleVM vm = _mapper.Map<KullaniciEkleVM>(request);
            var response = await _userService.CreateAsync(vm);
            if (response.Succeeded)
            {
                //mail gönder
                
                return new()
                {
                    result = true
                };
            }
            else
            {
                string message = "";
                foreach (var error in response.Errors)
                    message += $"{error.Code} - {error.Description}";

                return new()
                {
                    result = message
                };
            }

        }
    }
}
