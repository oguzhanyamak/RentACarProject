using MediatR;
using RentACarProject.Application.Repositories.Arac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Sube.GetAracs
{
    public class GetAracsQueryRequestHandler : IRequestHandler<GetAracsQueryRequest, GetAracsQueryResponse>
    {
        private readonly IAracReadRepositoy _aracReadRepositoy;
        public GetAracsQueryRequestHandler(IAracReadRepositoy aracReadRepositoy)
        {
            _aracReadRepositoy = aracReadRepositoy;
        }
        public async Task<GetAracsQueryResponse> Handle(GetAracsQueryRequest request, CancellationToken cancellationToken)
        {
            var araclar = _aracReadRepositoy.GetWhere(i => i.Sube.Id == request.SubeId);
            return new()
            {
                Araclar = araclar
            };
        }
    }
}
