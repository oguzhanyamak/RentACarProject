using AutoMapper;
using MediatR;
using RentACarProject.Application.Exceptions;
using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Arac.CreateArac
{
    public class CreateAracCommandHandler : IRequestHandler<CreateAracCommandRequest, CreateAracCommandResponse>
    {
        private readonly IAracWriteAsyncRepository _aracWriteAsyncRepository;
        private readonly IAracWriteRepository _aracWriteRepository;
        private readonly ISubeReadAsyncRepository _subeReadAsyncRepository;
        private readonly IMapper _mapper;

        public CreateAracCommandHandler(IAracWriteRepository aracWriteRepository, IAracWriteAsyncRepository aracWriteAsyncRepository, ISubeReadAsyncRepository subeReadAsyncRepository, IMapper mapper)
        {
            _aracWriteRepository = aracWriteRepository;
            _aracWriteAsyncRepository = aracWriteAsyncRepository;
            _subeReadAsyncRepository = subeReadAsyncRepository;
            _mapper = mapper;
        }

        public async Task<CreateAracCommandResponse> Handle(CreateAracCommandRequest request, CancellationToken cancellationToken)
        {
            
            if(request.SubeId == Guid.Empty || request.Plaka == "" || request.Plaka == String.Empty ||request.Plaka == null)
            {
                throw new BadRequestException("Id veya Plaka bos Gecilemez");
            }

            Domain.Entites.Sube sube = await _subeReadAsyncRepository.GetSingleAsync(i => i.Id == request.SubeId);
            if(sube is null)
            {
                throw new NotFoundException($" böyle bir sube yok : {request.SubeId} ");
            }

            Domain.Entites.Arac arac = _mapper.Map<Domain.Entites.Arac>(request);
            arac.Sube = sube;
            arac.Id = Guid.NewGuid();
            bool res = await _aracWriteAsyncRepository.AddAsync(arac);
            int res1 = await _aracWriteAsyncRepository.SaveAsync();
            res = (res == true && res1 == 1) ? true : false;
            return new()
            {
                result = res,
                objectId = arac.Id.ToString()
            };
        }
    }
}
