using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Domain.Entites
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            KullaniciSiparis = new HashSet<KullaniciSiparis>();
        }
        public virtual ICollection<KullaniciSiparis> KullaniciSiparis { get; set; }
        public UserBio UserBio { get; set; }
    }
}
