using RentACarProject.Application.Repositories.Siparis;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Siparis
{
    public class SiparisReadAsyncRepository : ReadAsyncRepository<Domain.Entites.Siparis>, ISiparisReadAsyncRepository
    {
        public SiparisReadAsyncRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
