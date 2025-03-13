using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Persons)
               .WithOne(x => x.City)
               .HasForeignKey(x => x.CityId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
