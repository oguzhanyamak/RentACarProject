using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Domain.Entites
{
    public class KullaniciSiparis 
    {
        public string KullaniciId { get; set; }
        public Guid SiparisId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Siparis Siparis { get; set; }
    }
}
