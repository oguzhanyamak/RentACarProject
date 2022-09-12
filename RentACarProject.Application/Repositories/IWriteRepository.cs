using RentACarProject.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        bool Add(T Entity);
        bool AddRange(List<T> datas);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        bool Update(T model);
        int SaveChanges();
    }
}
