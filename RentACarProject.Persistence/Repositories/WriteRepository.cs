using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RentACarProject.Application.Repositories;
using RentACarProject.Domain.Entites;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly RentACarDbContext _context;

        public WriteRepository(RentACarDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public bool Add(T Entity)
        {
            EntityEntry<T> entityEntry = Table.Add(Entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool AddRange(List<T> datas)
        {
            Table.AddRange(datas);
            return true;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
