using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Sube.GetById
{
    public class GetSubeByIdQueryRequest : IRequest<GetSubeByIdQueryResponse>
    {
        public Guid SubeId { get; set; }
    }
}
