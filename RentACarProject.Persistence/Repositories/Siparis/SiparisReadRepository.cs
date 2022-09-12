using RentACarProject.Application.Repositories;
using RentACarProject.Application.Repositories.Siparis;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Siparis
{
    public class SiparisReadRepository : ReadRepository<Domain.Entites.Siparis>, ISiparisReadRepository
    {
        public SiparisReadRpository(RentACarDbContext context) : base(context)
        {
        }
    }
}
