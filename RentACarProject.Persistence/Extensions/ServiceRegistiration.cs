using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentACarProject.Application.Repositories.Arac;
using RentACarProject.Application.Repositories.Kullanici;
using RentACarProject.Application.Repositories.Siparis;
using RentACarProject.Application.Repositories.Sube;
using RentACarProject.Persistence.Context;
using RentACarProject.Persistence.Repositories.Arac;
using RentACarProject.Persistence.Repositories.Kullanici;
using RentACarProject.Persistence.Repositories.Siparis;
using RentACarProject.Persistence.Repositories.Sube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Persistence.Extensions
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<RentACarDbContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=rentCar;Integrated Security=True;"));
            services.AddScoped<IAracReadRepositoy, AracReadRepository>();
            services.AddScoped<IAracReadAsyncRepository, AracReadAsyncRepository>();
            services.AddScoped<IAracWriteAsyncRepository, AracWriteAsyncRepository>();
            services.AddScoped<IAracWriteRepository, AracWriteRepository>();
            services.AddScoped<IKullaniciReadAsyncRepository, KullaniciReadAsyncRepository>();
            services.AddScoped<IKullaniciReadRepository, KullaniciReadRepository>();
            services.AddScoped<IKullaniciWriteAsyncRepository, KullaniciWriteAsyncRepository>();
            services.AddScoped<IKullaniciWriteRepository, KullaniciWriteRepository>();
            services.AddScoped<ISubeReadAsyncRepository, SubeReadAsyncRepository>();
            services.AddScoped<ISubeReadRepository, SubeReadRepository>();
            services.AddScoped<ISubeWriteAsyncRepository, SubeWriteAsyncRepository>();
            services.AddScoped<ISubeWriteRepository, SubeWriteRepository>();
            services.AddScoped<ISiparisReadAsyncRepository, SiparisReadAsyncRepository>();
            services.AddScoped<ISiparisReadRepository, SiparisReadRepository>();
            services.AddScoped<ISiparisWriteAsyncRepository, SiparisWriteAsyncRepository>();
            services.AddScoped<ISiparisWriteRepository, SiparisWriteRepository>();
        }
    }
}
