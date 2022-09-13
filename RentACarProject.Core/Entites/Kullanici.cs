using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Domain.Entites
{
    public class Kullanici : BaseEntity
    {
        public Kullanici()
        {
            KullaniciSiparis = new HashSet<KullaniciSiparis>();
        }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TC { get; set; }
        public string Ulke { get; set; }
        public string Sehir { get; set; }
        public string Cadde { get; set; }
        public string AdresDetay { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<KullaniciSiparis> KullaniciSiparis { get; set; }
    }
}
