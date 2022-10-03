using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Sube.GetAracs
{
    public class GetAracsQueryRequest :IRequest<GetAracsQueryResponse>
    {
        public Guid SubeId { get; set; }
    }
}
