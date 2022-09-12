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
        public KullaniciReadRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
