using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Domain.Entites;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Arac
{
    public class AracReadAsyncRepository : ReadAsyncRepository<Domain.Entites.Arac>, IAracReadAsyncRepository
    {
        public AracReadAsyncRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
