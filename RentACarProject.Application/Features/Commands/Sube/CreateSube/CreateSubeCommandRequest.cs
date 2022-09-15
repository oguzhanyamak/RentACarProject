using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Sube.CreateSube
{
    public class CreateSubeCommandRequest : IRequest<CreateSubeCommandResponse>
    {
        public string SubeAdi { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Cadde { get; set; }
        public string Detay { get; set; }
    }
}
