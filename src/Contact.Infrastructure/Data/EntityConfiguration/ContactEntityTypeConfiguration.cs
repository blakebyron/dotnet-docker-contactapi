using System;
namespace Contact.Infrastructure.Data.EntityConfiguration
{
    using Contact.Domain.Aggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public ContactEntityTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");
            builder.HasKey(x => x.ID)
                .HasName("ContactID");
            builder.Property(p => p.FirstName)
                .HasMaxLength(50);
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.Organisation)
                .HasMaxLength(50);

        }
    }
}
