using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using RentACarProject.Application.Repositories.Kullanici;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Kullanici.KullaniciSiparisleri
{
    public class GetKullaniciSiparisleriQueryRequestHandler : IRequestHandler<GetKullaniciSiparisleriQueryRequest, GetKullaniciSiparisleriQueryResponse>
    {
        private readonly IKullaniciReadRepository _readRepository;

        public GetKullaniciSiparisleriQueryRequestHandler(IKullaniciReadRepository readRepository)
        {
            _readRepository = readRepository;
        }
        public async Task<GetKullaniciSiparisleriQueryResponse> Handle(GetKullaniciSiparisleriQueryRequest request, CancellationToken cancellationToken)
        {
            var siparisler = _readRepository.KullaniciSiparisleri(request.KullaniciId);

            return new()
            {
                Siparisler = siparisler
            };
        }
    }
}
