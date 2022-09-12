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
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly RentACarDbContext _context;

        public ReadRepository(RentACarDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IEnumerable<T> GetAll(bool tracking = true)
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(string id, bool tracking = true)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(data => data.Id == Guid.Parse(id));
        }

        public T GetSingle(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return _context.Set<T>().AsNoTracking().Where(method);
        }
    }
}
