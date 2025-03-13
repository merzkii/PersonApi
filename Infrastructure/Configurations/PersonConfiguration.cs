using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Gender)
               .IsRequired()
               .HasConversion<string>();

            builder.Property(p => p.PersonalNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.HasOne(p => p.City)
                .WithMany(p=>p.Persons)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.PhoneNumbers)
                .WithOne(pn => pn.Person)
                .HasForeignKey(pn => pn.PersonId);

            builder.HasMany(p => p.RelatedIndividuals)
                .WithOne(cp => cp.Person)
                .HasForeignKey(cp => cp.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.RelatedIndividuals)
                .WithOne(cp => cp.RelatedPerson)
                .HasForeignKey(cp => cp.ConnectedPersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
