using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.UpdatePassword
{
    public class UpdatePasswordQueryRequest :IRequest<UpdatePasswordQueryResponse>
    {
        public string email { get; set; }
        public string newPassword { get; set; }
        public string oldPassword { get; set; }
    }
}
