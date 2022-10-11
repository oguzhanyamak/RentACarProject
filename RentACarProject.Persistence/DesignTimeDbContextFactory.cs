using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RentACarProject.Persistence;
using RentACarProject.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RentACarDbContext>
    {
        public RentACarDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<RentACarDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rentCar;Integrated Security=True;");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
