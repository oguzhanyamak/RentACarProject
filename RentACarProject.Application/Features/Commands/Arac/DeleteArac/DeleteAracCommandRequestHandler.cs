using MediatR;
using RentACarProject.Application.Repositories.Arac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Arac.DeleteArac
{
    public class DeleteAracCommandRequestHandler : IRequestHandler<DeleteAracCommandRequest, DeleteAracCommandResponse>
    {
        private readonly IAracReadAsyncRepository _aracReadAsync;
        private readonly IAracWriteRepository _aracWrite;

        public DeleteAracCommandRequestHandler(IAracWriteRepository aracWrite, IAracReadAsyncRepository aracReadAsync)
        {
            _aracWrite = aracWrite;
            _aracReadAsync = aracReadAsync;
        }
        public async Task<DeleteAracCommandResponse> Handle(DeleteAracCommandRequest request, CancellationToken cancellationToken)
        {
            var arac = await _aracReadAsync.GetByIdAsync(request.AracId.ToString());
            if(arac is not null)
            {
                arac.GenelDurum = false;
                _aracWrite.Update(arac);
                _aracWrite.SaveChanges();
                return new()
                {
                    Result = true
                };
            }
            else
            {
                return new()
                {
                    Result = false
                };
            }

        }
    }
}
