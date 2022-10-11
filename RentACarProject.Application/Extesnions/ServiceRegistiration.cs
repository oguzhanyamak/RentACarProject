using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Application.Extesnions
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddApplicationRegistiration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly(); //çalışılan assembly (katman) i getirir
            services.AddMediatR(assm);
            services.AddAutoMapper(assm);
            return services;
        }
    }
}
