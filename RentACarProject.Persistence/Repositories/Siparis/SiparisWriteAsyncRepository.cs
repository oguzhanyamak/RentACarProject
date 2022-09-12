using RentACarProject.Application.Repositories.Siparis;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Siparis
{
    public class SiparisWriteAsyncRepository : WriteAsyncRepository<Domain.Entites.Siparis>, ISiparisWriteAsyncRepository
    {
        public SiparisWriteAsyncRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
