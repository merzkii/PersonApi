using Core.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Layer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<ConnectedPerson> ConnectedPersons { get; set; }
        public DbSet<SharedPhone> SharedPhones { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ConnectedPersonConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new SharedPhoneConfiguration());
        }
    }

}
