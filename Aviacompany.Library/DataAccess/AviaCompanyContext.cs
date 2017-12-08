using System.Data.Entity;
using Aviacompany.Library.Entities;
using Aviacompany.Library.Infrastrucutre;
using Aviacompany.Library.Models;
using Microsoft.AspNet.Identity;
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

        public DbSet<Employee> Employees { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightStatus> FlightStatuses { get; set; }

        public DbSet<Brigade> Brigades { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamEmployee> TeamEmployees { get; set; }

        public DbSet<TeamType> TeamTypes { get; set; }

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

            modelBuilder.Entity<Brigade>()
                .HasOptional(m => m.PilotTeam)
                .WithMany(t => t.Pilots)
                .HasForeignKey(m => m.PilotTeamId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brigade>()
                .HasOptional(m => m.NavigatorTeam)
                .WithMany(t => t.Navigators)
                .HasForeignKey(m => m.NavigatorTeamId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brigade>()
                .HasOptional(m => m.StewardessTeam)
                .WithMany(t => t.Stewardesses)
                .HasForeignKey(m => m.StewardessTeamId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Brigade>()
                .HasOptional(m => m.OperatorTeam)
                .WithMany(t => t.Operators)
                .HasForeignKey(m => m.OperatorTeamId)
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
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));

            string roleName = "Administrators";
            string userName = "Admin";
            string password = "mypassword";
            string email = "admin@professorweb.ru";

            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new AppRole(roleName));
            }

            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email },
                    password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
        }
    }
}