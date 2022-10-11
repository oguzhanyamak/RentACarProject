using MediatR;
using RentACarProject.Application.Repositories.Arac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Arac.UpdateArac
{
    public class UpdateAracCommandHandler : IRequestHandler<UpdateAracCommandRequest, UpdateAracCommandResponse>
    {
        private readonly IAracReadAsyncRepository _aracReadAsyncRepository;
        private readonly IAracWriteAsyncRepository _aracWriteAsyncRepository;
        private readonly IAracWriteRepository _aracWriteRepository;

        public UpdateAracCommandHandler(IAracReadAsyncRepository aracReadAsyncRepository, IAracWriteAsyncRepository aracWriteAsyncRepository, IAracWriteRepository aracWriteRepository)
        {
            _aracReadAsyncRepository = aracReadAsyncRepository;
            _aracWriteAsyncRepository = aracWriteAsyncRepository;
            _aracWriteRepository = aracWriteRepository;
        }
        public async Task<UpdateAracCommandResponse> Handle(UpdateAracCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entites.Arac arac = await _aracReadAsyncRepository.GetByIdAsync(request.AracId.ToString());
            arac.SaatUcreti = request.SaatUcreti;
            bool res = _aracWriteRepository.Update(arac);
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
