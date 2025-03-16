using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Gender)
               .IsRequired();
               

            builder.Property(p => p.PersonalNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.DateOfBirth)
                .IsRequired();

            builder.Property(p => p.ImagePath);
                



        }
    }
}
