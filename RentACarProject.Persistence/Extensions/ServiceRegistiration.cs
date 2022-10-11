using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentACarProject.Application.Abstraction.Services;
using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Application.Repositories.Siparis;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Domain.Entites.Role;
using RentACarProject.Domain.Entites;
using RentACarProject.Persistence.Context;
using RentACarProject.Persistence.Repositories.Arac;
using RentACarProject.Persistence.Repositories.Siparis;
using RentACarProject.Persistence.Repositories.Sube;
using RentACarProject.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RentACarProject.Persistence.Extensions
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            
            services.AddDbContext<RentACarDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rentCar;Integrated Security=True;"));
            services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<RentACarDbContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IAracReadRepositoy, AracReadRepository>();
            services.AddScoped<IAracReadAsyncRepository, AracReadAsyncRepository>();
            services.AddScoped<IAracWriteAsyncRepository, AracWriteAsyncRepository>();
            services.AddScoped<IAracWriteRepository, AracWriteRepository>();
            services.AddScoped<ISubeReadAsyncRepository, SubeReadAsyncRepository>();
            services.AddScoped<ISubeReadRepository, SubeReadRepository>();
            services.AddScoped<ISubeWriteAsyncRepository, SubeWriteAsyncRepository>();
            services.AddScoped<ISubeWriteRepository, SubeWriteRepository>();
            services.AddScoped<ISiparisReadAsyncRepository, SiparisReadAsyncRepository>();
            services.AddScoped<ISiparisReadRepository, SiparisReadRepository>();
            services.AddScoped<ISiparisWriteAsyncRepository, SiparisWriteAsyncRepository>();
            services.AddScoped<ISiparisWriteRepository, SiparisWriteRepository>();

            
            //services.AddTransient<IAuthService, AuthService>();

        }
    }
}
