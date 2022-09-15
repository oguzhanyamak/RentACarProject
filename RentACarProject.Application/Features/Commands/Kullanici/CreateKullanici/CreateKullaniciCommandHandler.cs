using AutoMapper;
using MediatR;
using RentACarProject.Application.Repositories.Kullanici;
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
        private readonly IKullaniciWriteAsyncRepository _kullaniciWriteAsyncRepository;
        public CreateKullaniciCommandHandler(IMapper mapper, IKullaniciWriteAsyncRepository kullaniciWriteAsyncRepository)
        {
            _mapper = mapper;
            _kullaniciWriteAsyncRepository = kullaniciWriteAsyncRepository;
        }
        public async Task<CreateKullaniciCommandResponse> Handle(CreateKullaniciCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entites.Kullanici kullanici = _mapper.Map<Domain.Entites.Kullanici>(request);
            kullanici.Id = Guid.NewGuid();
            bool res = await _kullaniciWriteAsyncRepository.AddAsync(kullanici);
            await _kullaniciWriteAsyncRepository.SaveAsync();
            return new()
            {
                result = res
            };
        }
    }
}
