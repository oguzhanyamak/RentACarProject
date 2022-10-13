using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RentACarProject.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<GlobalExceptionHandler>();
            return builder;
        }
    }
}
