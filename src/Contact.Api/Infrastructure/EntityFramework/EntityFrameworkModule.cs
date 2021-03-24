using System;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using af = Autofac.Module;
using System.Collections.Generic;
using Contact.Infrastructure.Data;

namespace Contact.Api.Infrastructure.EntityFramework
{
    public class EntityFrameworkModule : af
    {
        private readonly string ConnectionString;
        private readonly bool IsInMemoryDummyDataRequired;


        public EntityFrameworkModule(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            };
            this.IsInMemoryDummyDataRequired = configuration.GetValue<bool>("ApiSettings:IsDummyDataRequired");
            this.ConnectionString = configuration["ConnectionString"];
        }
        protected override void Load(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            if (IsInMemoryDummyDataRequired)
            {
                AddDummyData(optionsBuilder.Options);
            }

            builder.Register<ContactDbContext>(ctx =>
            {
                return new ContactDbContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            base.Load(builder);
        }

        protected void AddDummyData(DbContextOptions<ContactDbContext> contextOptions)
        {
            var ctx = new ContactDbContext(contextOptions);
            ctx.Contacts.AddRangeAsync(GetDummyDataItems());
            ctx.SaveChanges();
        }

        private IEnumerable<Contact.Domain.Aggregate.Contact> GetDummyDataItems()
        {
            return new List<Contact.Domain.Aggregate.Contact>()
            {
            };
        }
    }
}
