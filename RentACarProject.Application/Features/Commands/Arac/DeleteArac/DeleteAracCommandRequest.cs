using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Arac.DeleteArac
{
    public class DeleteAracCommandRequest : IRequest<DeleteAracCommandResponse>
    {
        public Guid AracId { get; set; }
    }
}
