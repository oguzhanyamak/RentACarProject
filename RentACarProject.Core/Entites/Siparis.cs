using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Domain.Entites
{
    public class Siparis : BaseEntity
    {
        public Siparis()
        {
            KullaniciSiparis = new HashSet<KullaniciSiparis>();
        }
        public DateTime AlisZamani { get; set; }
        public DateTime TeslimZamani { get; set; }
        public float ToplamUcret { get; set; }
        public Guid TeslimSubeId { get; set; }
        public bool Durum { get; set; }
        public virtual Sube Sube { get; set; }
        public virtual Arac arac { get; set; }
        public virtual ICollection<KullaniciSiparis> KullaniciSiparis { get; set; }
    }
}
