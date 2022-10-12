using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.KullaniciRole
{
    public class KullaniciRoleCommandRequest :IRequest<KullaniciRoleCommandResponse>
    {
        public string RoleId { get; set; }
        public string KullaniciId { get; set; }
    }
}
