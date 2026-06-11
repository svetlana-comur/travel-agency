using Microsoft.EntityFrameworkCore;
using TravelAgency.Domains.Entities.Hotel;
using TravelAgency.Domains.Entities.User;

namespace TravelAgency.DataAccess.Context
{
    public class HotelContext : DbContext
    {
        public DbSet<HotelData> Hotels { get; set; }
        public DbSet<HotelRoomData> Rooms { get; set; }
        public DbSet<HotelBookingData> HotelBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoomData>()
                .HasOne(x => x.Hotel)
                .WithMany(x => x.Rooms)
                .HasForeignKey(x => x.HotelId);

            modelBuilder.Entity<HotelBookingData>()
                .HasOne(x => x.Hotel)
                .WithMany()
                .HasForeignKey(x => x.HotelId);
        }
    }
}