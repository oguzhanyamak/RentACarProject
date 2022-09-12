using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Arac
{
    public class AracWriteRepository : WriteRepository<Domain.Entites.Arac>, IAracWriteRepository
    {
        public AracWriteRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
