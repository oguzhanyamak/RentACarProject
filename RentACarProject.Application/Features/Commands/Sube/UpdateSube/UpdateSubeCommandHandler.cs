using AutoMapper;
using MediatR;
using RentACarProject.Application.Repositories.Sube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Sube.UpdateSube
{
    public class UpdateSubeCommandHandler : IRequestHandler<UpdateSubeCommandRequest, UpdateSubeCommandResponse>
    {
        private readonly ISubeReadAsyncRepository _subeReadAsyncRepository;
        private readonly ISubeWriteRepository _subeWriteRepository;
        private readonly IMapper _mapper;

        public UpdateSubeCommandHandler(ISubeReadAsyncRepository subeReadAsyncRepository, ISubeWriteRepository subeWriteRepository, IMapper mapper)
        {
            _subeReadAsyncRepository = subeReadAsyncRepository;
            _subeWriteRepository = subeWriteRepository;
            _mapper = mapper;
        }
        public async Task<UpdateSubeCommandResponse> Handle(UpdateSubeCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entites.Sube sube = await _subeReadAsyncRepository.GetByIdAsync(request.Id.ToString());
            sube.Sehir = request.Sehir;
            sube.Ulke = request.Ulke;
            sube.Cadde = request.Cadde;
            sube.AdresDetay = request.AdresDetay;
            bool res = _subeWriteRepository.Update(sube);
            _subeWriteRepository.SaveChanges();
            return new() { result = res };
        }
    }
}
