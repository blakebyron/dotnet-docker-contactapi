using Xunit;
using Contact.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Contact.FunctionalTests
{
    [Collection("Database")]
    public class ContactApiWebApplicationFactory : WebApplicationFactory<Startup>
    {
        private readonly DatabaseFixture fixture;

        public ContactApiWebApplicationFactory(DatabaseFixture fixture)
        {
            this.fixture = fixture;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            //  builder.UseEnvironment("Test");

            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("ConnectionStrings", fixture.ConnectionString)
                });
            });
        }
    }
}
