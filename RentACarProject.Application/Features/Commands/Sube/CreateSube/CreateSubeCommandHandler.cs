using AutoMapper;
using MediatR;
using RentACarProject.Application.Repositories.Sube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Sube.CreateSube
{
    public class CreateSubeCommandHandler : IRequestHandler<CreateSubeCommandRequest, CreateSubeCommandResponse>
    {
        private readonly ISubeWriteAsyncRepository _subeWriteAsyncRepository;
        private readonly ISubeWriteRepository _subeWriteRepository;
        private readonly IMapper _mapper;

        public CreateSubeCommandHandler(ISubeWriteAsyncRepository subeWriteAsyncRepository, ISubeWriteRepository subeWriteRepository, IMapper mapper)
        {
            _subeWriteAsyncRepository = subeWriteAsyncRepository;
            _subeWriteRepository = subeWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateSubeCommandResponse> Handle(CreateSubeCommandRequest request, CancellationToken cancellationToken)
        {
            var sube = _mapper.Map<Domain.Entites.Sube>(request);
            sube.Id = Guid.NewGuid();
            bool res = await _subeWriteAsyncRepository.AddAsync(sube);
            await _subeWriteAsyncRepository.SaveAsync();
            return new()
            {
                result = res
            };
        }
    }
}
