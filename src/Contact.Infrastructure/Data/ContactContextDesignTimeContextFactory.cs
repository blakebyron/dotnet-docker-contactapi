using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Contact.Infrastructure.Data
{
    public class ContactContextDesignTimeContextFactory:IDesignTimeDbContextFactory<ContactDbContext>
    {
        public ContactContextDesignTimeContextFactory()
        {
        }

        public ContactDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContactDbContext>()
                .UseSqlServer("Server=.;Initial Catalog=ContactDb;Integrated Security=true");

            return new ContactDbContext(optionsBuilder.Options);
        }
    }
}
