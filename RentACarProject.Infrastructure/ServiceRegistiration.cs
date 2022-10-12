using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RentACarProject.Application.Abstraction.Token;
using RentACarProject.Application.Repositories.Arac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<Application.Abstraction.Token.ITokenHandler,Infrastructure.Services.TokenHandler>();
        }
    }
}
