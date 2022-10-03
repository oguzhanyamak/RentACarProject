using Microsoft.EntityFrameworkCore;
using RentACarProject.Application.Repositories.Kullanici;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Kullanici
{
    public class KullaniciReadRepository : ReadRepository<Domain.Entites.Kullanici>, IKullaniciReadRepository
    {
        private readonly RentACarDbContext _context;
        public KullaniciReadRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }

        public object KullaniciSiparisleri(Guid KullaniciId)
        {
            return _context.Kullanicilar.Include(i => i.KullaniciSiparis).ThenInclude(i => i.Siparis).ThenInclude(i=> i.arac).ThenInclude(i=>i.Sube).Where(i => i.Id == KullaniciId).ToList();
        }
    }
}
