using MediatR;
using RentACarProject.Application.Repositories.Sube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Sube.GetAll
{
    public class GetAllSubeQueryRequestHandler : IRequestHandler<GetAllSubeQueryRequest, GetAllSubeQueryResponse>
    {
        private readonly ISubeReadRepository _subeReadRepository;

        public GetAllSubeQueryRequestHandler(ISubeReadRepository subeReadRepository)
        {
            _subeReadRepository = subeReadRepository;
        }

        public async Task<GetAllSubeQueryResponse> Handle(GetAllSubeQueryRequest request, CancellationToken cancellationToken)
        {
            var subeler = _subeReadRepository.GetAll();
            return new()
            {
                Subeler = subeler,
            };
        }
    }
}