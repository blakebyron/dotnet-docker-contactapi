using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Contact.Api.Infrastructure.HealthChecks
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfiguration configuration)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            string t = configuration["ConnectionString"];


            hcBuilder
                .AddSqlServer(
                    configuration["ConnectionString"],
                    name: "ContactDb-check",
                    tags: new string[] { "contactdb" });

            return services;
        }
    }
}
