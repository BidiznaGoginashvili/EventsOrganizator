using OA.DATA.Events;
using OA.DATA.Company;
using OA.DATA.Category;
using Microsoft.EntityFrameworkCore;

namespace OA.REPO.EventsOrganizerContext
{
    public class EventsOrganizerContext : DbContext
    {
        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //   .AddJsonFile("reposettings.json")
            //   .Build();

            optionsBuilder.UseSqlServer("Server=DESKTOP-OKIRIV8; Database=EventsOrganization; Trusted_Connection=True");
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Event> Event { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Company> Company { get; set; }
    }
}
