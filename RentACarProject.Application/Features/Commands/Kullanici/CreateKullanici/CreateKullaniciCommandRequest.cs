using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Features.Commands.Kullanici.CreateKullanici
{
    public class CreateKullaniciCommandRequest :IRequest<CreateKullaniciCommandResponse>
    {
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string SifreOnay { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Cadde { get; set; }
        public string AdresDetay { get; set; }
        public bool Durum { get; set; }
    }
}
