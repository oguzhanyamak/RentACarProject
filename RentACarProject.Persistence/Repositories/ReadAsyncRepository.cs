using Microsoft.EntityFrameworkCore;
using RentACarProject.Application.Repositories;
using RentACarProject.Domain.Entites;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories
{
    public class ReadAsyncRepository<T> : IReadAsyncRepository<T> where T : BaseEntity
    {

        readonly private RentACarDbContext _context;

        public ReadAsyncRepository(RentACarDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
    }
}
 