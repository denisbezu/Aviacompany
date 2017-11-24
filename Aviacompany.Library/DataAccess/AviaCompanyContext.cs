using System.Data.Entity;
using Aviacompany.Library.Entities;
using Aviacompany.Library.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Aviacompany.Library.DataAccess
{
    public class AviaCompanyContext : IdentityDbContext<AppUser>
    {

        public AviaCompanyContext() : base("name=AviaCompanyContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        static AviaCompanyContext()
        {
            Database.SetInitializer<AviaCompanyContext>(new AviaCompanyContextInit());
        }

        public static AviaCompanyContext Create()
        {
            return new AviaCompanyContext();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightStatus> FlightStatuses { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight>()
                .HasOptional(m => m.FlightFromCity)
                .WithMany(t => t.FlightsFrom)
                .HasForeignKey(m => m.FlightFrom)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flight>()
                .HasOptional(m => m.FlightToCity)
                .WithMany(t => t.FlightsTo)
                .HasForeignKey(m => m.FlightTo)
                .WillCascadeOnDelete(false);

        }
    }

    public class AviaCompanyContextInit : DropCreateDatabaseIfModelChanges<AviaCompanyContext>
    {
        protected override void Seed(AviaCompanyContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }
        public void PerformInitialSetup(AviaCompanyContext context)
        {
            // настройки конфигурации контекста будут указываться здесь
        }
    }
}