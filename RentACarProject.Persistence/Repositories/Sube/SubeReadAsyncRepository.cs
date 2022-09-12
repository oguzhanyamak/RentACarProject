using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Sube
{
    public class SubeReadAsyncRepository : ReadAsyncRepository<Domain.Entites.Sube>, ISubeReadAsyncRepository
    {
        public SubeReadAsyncRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}
