using RentACarProject.Application.Repositories.Kullanici;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Kullanici
{
    public class KullaniciReadAsyncRepository : ReadAsyncRepository<Domain.Entites.Kullanici>, IKullaniciReadAsyncRepository
    {
        public KullaniciReadAsyncRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
