using System;
using Contact.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Polly;

namespace Contact.Api.Infrastructure.EntityFramework
{
    public static class IWebHostExtensions
    {

        public static void CreateDataBase(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<ContactDbContext>>();
                var context = services.GetService<ContactDbContext>();

                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(ContactDbContext).Name);

                    var retries = 10;
                    var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(
                            retryCount: retries,
                            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                            onRetry: (exception, timeSpan, retry, ctx) =>
                            {
                                logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", nameof(ContactDbContext), exception.GetType().Name, exception.Message, retry, retries);
                            });
                            retry.Execute(() =>
                            {
                                //Swap out for migrate command when migrations is to be used.
                                context.Database.EnsureCreated();

                                context.Contacts.Add(Domain.Aggregate.Contact.Create("Paul", "Smith", null));
                                context.Contacts.Add(Domain.Aggregate.Contact.Create("Adam", "Davidson", "Company A"));
                                context.Contacts.Add(Domain.Aggregate.Contact.Create("Dave", "Jones", "Company B"));
                                context.SaveChanges();
                            }

                    );
                    logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(ContactDbContext).Name);

                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(ContactDbContext).Name);
                }


            }
        }
    }
}
