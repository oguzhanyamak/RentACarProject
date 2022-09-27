using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Arac.UpdateArac
{
    public class UpdateAracCommandRequest : IRequest<UpdateAracCommandResponse>
    {
        public Guid AracId { get; set; }
        public float SaatUcreti { get; set; }
    }
}
