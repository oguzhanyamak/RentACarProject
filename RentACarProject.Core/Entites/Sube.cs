using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Domain.Entites
{
    public class Sube : BaseEntity
    {
        public string SubeAdi { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Cadde { get; set; }
        public string AdresDetay { get; set; }
    }
}
