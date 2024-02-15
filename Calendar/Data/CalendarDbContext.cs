using Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Data
{
    public class CalendarDbContext : DbContext
    {
        public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CalendarModel>();
            modelBuilder.Entity<ConsultantModel>();
        }

        public DbSet<CalendarModel> Calendars { get; set; }
        public DbSet<ConsultantModel> Consultants { get; set; }
    }
}
