using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Arac
{
    public class AracReadRepository : ReadRepository<Domain.Entites.Arac>, IAracReadRepositoy
    {
        public AracReadRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
