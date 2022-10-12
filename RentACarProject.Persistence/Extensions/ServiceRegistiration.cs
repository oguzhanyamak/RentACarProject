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
            services.AddIdentity<AppUser, AppRole>(_ =>
            {
                _.Password.RequiredLength = 5; //En az kaç karakterli olması gerektiğini belirtiyoruz.
                _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluğunu kaldırıyoruz.
                _.Password.RequireLowercase = false; //Küçük harf zorunluluğunu kaldırıyoruz.
                _.Password.RequireUppercase = false; //Büyük harf zorunluluğunu kaldırıyoruz.
                _.Password.RequireDigit = false; //0-9 arası sayısal karakter zorunluluğunu kaldırıyoruz.

                _.User.RequireUniqueEmail = true;
                _.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+"; //Kullanıcı adında geçerli olan karakterleri belirtiyoruz.
            }).AddEntityFrameworkStores<RentACarDbContext>().AddDefaultTokenProviders();



            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
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
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMailService, MailService>();




            services.AddHttpClient();
        }
    }
}
