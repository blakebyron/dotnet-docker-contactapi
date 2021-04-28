using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Contact.Api.Infrastructure.HealthChecks
{
    public class EntityFrameworkPendingMigrationHealthCheck<TContext> : IHealthCheck where TContext : DbContext
    {
        private readonly TContext _dbContext;

        public EntityFrameworkPendingMigrationHealthCheck(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            IEnumerable<string> pending = await _dbContext.Database
                .GetPendingMigrationsAsync(cancellationToken);
            string[] migrations = pending as string[] ?? pending.ToArray();
            var isHealthy = !migrations.Any();

            return isHealthy
                ? HealthCheckResult.Healthy("No pending db migrations")
                : HealthCheckResult.Unhealthy($"{migrations.Length} migrations pending!");
        }
    }
}
