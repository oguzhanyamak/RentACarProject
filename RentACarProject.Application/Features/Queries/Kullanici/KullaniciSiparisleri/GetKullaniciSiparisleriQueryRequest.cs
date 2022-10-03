using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Kullanici.KullaniciSiparisleri
{
    public class GetKullaniciSiparisleriQueryRequest :IRequest<GetKullaniciSiparisleriQueryResponse>
    {
        public Guid KullaniciId { get; set; }
    }
}
