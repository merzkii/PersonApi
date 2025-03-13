using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Number)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Type)
                .IsRequired()
                .HasConversion<string>(); 

           
            builder.HasIndex(p => p.Number).IsUnique(false);
        }
    }
}
