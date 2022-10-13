using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Arac.CreateArac
{
    public class CreateAracCommandRequest : IRequest<CreateAracCommandResponse>
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string MotorHacmi { get; set; }
        public string BeygirGucu { get; set; }
        public string VitesTuru { get; set; }
        public float SaatUcreti { get; set; }
        public bool Durum { get; set; }
        public string Plaka { get; set; }
        public Guid SubeId { get; set; }
    }
}
