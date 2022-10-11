using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Domain.Entites
{
    public class UserBio : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Cadde { get; set; }
        public string AdresDetay { get; set; } = null;
    }
}
