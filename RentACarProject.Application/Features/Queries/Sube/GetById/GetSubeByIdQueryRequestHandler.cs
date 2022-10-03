using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using RentACarProject.Application.Repositories.Sube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Queries.Sube.GetById
{
    public class GetSubeByIdQueryRequestHandler : IRequestHandler<GetSubeByIdQueryRequest, GetSubeByIdQueryResponse>
    {
        private readonly ISubeReadAsyncRepository _subeReadAsyncRepository;

        public GetSubeByIdQueryRequestHandler(ISubeReadAsyncRepository subeReadAsyncRepository)
        {
            _subeReadAsyncRepository = subeReadAsyncRepository;
        }

        public async Task<GetSubeByIdQueryResponse> Handle(GetSubeByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entites.Sube sube = await _subeReadAsyncRepository.GetByIdAsync(request.SubeId.ToString());
            return new()
            {
                sube = sube,
            };
        }
    }
}
