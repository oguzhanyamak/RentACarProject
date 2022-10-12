using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.UpdatePassword
{
    public class UpdatePasswordQueryResponse
    {
        public bool result { get; set; }
        public string? message { get; set; }
    }
}
