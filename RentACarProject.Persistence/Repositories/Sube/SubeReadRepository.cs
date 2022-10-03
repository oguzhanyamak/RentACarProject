using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories.Sube
{
    public class SubeReadRepository : ReadRepository<Domain.Entites.Sube>, ISubeReadRepository
    {
        private readonly RentACarDbContext _context;
        public SubeReadRepository(RentACarDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
