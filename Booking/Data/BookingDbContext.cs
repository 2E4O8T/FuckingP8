using Microsoft.EntityFrameworkCore;
using Booking.Models;

namespace Booking.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookingModel>();
            modelBuilder.Entity<ConsultantModel>();
            modelBuilder.Entity<PatientModel>();
        }

        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<ConsultantModel> Consultants { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
    }
}
