using MediatR;
using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Application.Repositories.Siparis;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RentACarProject.Application.Features.Commands.Siparis.Create
{
    public class CreateSiparisCommandHandler : IRequestHandler<CreateSiparisCommandRequest, CreateSiparisCommandResponse>
    {
        private readonly IAracReadAsyncRepository _aracReadAsyncRepository;
        private readonly ISubeReadAsyncRepository _subeReadAsyncRepository;
        private readonly ISiparisReadAsyncRepository _siparisReadAsyncRepository;
        private readonly ISiparisWriteAsyncRepository _siparisWriteAsyncRepository;
        public CreateSiparisCommandHandler(ISiparisWriteAsyncRepository siparisWriteAsyncRepository, ISiparisReadAsyncRepository siparisReadAsyncRepository, IAracReadAsyncRepository aracReadAsyncRepository, ISubeReadAsyncRepository subeReadAsyncRepository)
        {
            _siparisWriteAsyncRepository = siparisWriteAsyncRepository;
            _siparisReadAsyncRepository = siparisReadAsyncRepository;
            _aracReadAsyncRepository = aracReadAsyncRepository;
            _subeReadAsyncRepository = subeReadAsyncRepository;
        }

        public async Task<CreateSiparisCommandResponse> Handle(CreateSiparisCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entites.Arac arac = await _aracReadAsyncRepository.GetByIdAsync(request.AracId.ToString());
            Domain.Entites.Sube sube = await _subeReadAsyncRepository.GetByIdAsync(request.SubeId.ToString());
            Guid id = Guid.NewGuid();
            Domain.Entites.Siparis siparis = new()
            {
                arac = arac,
                AlisZamani = request.Alis,
                TeslimZamani = request.Teslim,
                Durum = true,
                Id = id,
                Sube = sube,
                TeslimSubeId = request.TSubeId,
                ToplamUcret = Convert.ToInt32(request.Teslim.Subtract(request.Alis).TotalHours) * arac.SaatUcreti,
                KullaniciSiparis = new HashSet<KullaniciSiparis>()
                {

                    new() { KullaniciId = request.KullaniciId, SiparisId =  id}
                },


            };
            bool res = await _siparisWriteAsyncRepository.AddAsync(siparis);
            int res2 = await _siparisWriteAsyncRepository.SaveAsync();

            return new()
            {
                Result = res
            };

        }
    }
}
