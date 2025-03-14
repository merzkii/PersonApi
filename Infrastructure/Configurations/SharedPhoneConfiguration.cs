using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class SharedPhoneConfiguration : IEntityTypeConfiguration<SharedPhone>
    {
        public void Configure(EntityTypeBuilder<SharedPhone> builder)
        {
            //builder.HasKey(sp => new { sp.PhoneId, sp.PersonId });

            builder.HasOne(sp => sp.Phone)
                   .WithMany(p => p.SharedPhone)
                   .HasForeignKey(sp => sp.PhoneId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sp => sp.Person)
                   .WithMany(p => p.PhoneNumbers)
                   .HasForeignKey(sp => sp.PersonId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
