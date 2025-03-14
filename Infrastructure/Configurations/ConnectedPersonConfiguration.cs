using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class ConnectedPersonConfiguration : IEntityTypeConfiguration<ConnectedPerson>
    {
        public void Configure(EntityTypeBuilder<ConnectedPerson> builder)
        {
            builder.Property(cp => cp.ConnectionType)
                .IsRequired();
                

            builder.HasOne(cp => cp.Person)
                .WithMany(p => p.RelatedIndividuals)
                .HasForeignKey(cp => cp.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(cp => cp.RelatedPerson)
                .WithMany()
                .HasForeignKey(cp => cp.ConnectedPersonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
