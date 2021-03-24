using System;
using Contact.Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Contact.Infrastructure.Data
{
    using Contact.Domain.Aggregate;

    public class ContactDbContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ContactDbContext()
        {
        }


        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactEntityTypeConfiguration());
            //Add-Migration InitialCreate -StartupProject Property.Infrastructure -Context PropertyContext -OutputDir "Data/Migrations" -Namespace Data.Migrations
            //remove-migration -startupproject Property.Infrastructure
            //Script-Migration -StartupProject Property.Infrastructure -From 0 -To InitialCreate -Project Property.Infrastructure 
        }
    }
}
