using Microsoft.EntityFrameworkCore;
using TravelAgency.Domains.Entities.Core;
using TravelAgency.Domains.Entities.Booking;
using TravelAgency.Domains.Entities.User;
using TravelAgency.Domains.Entities.Spa;
using TravelAgency.Domains.Entities.Hotel;
using TravelAgency.Domains.Entities.Place;
using TravelAgency.Domains.Entities.Package;

namespace TravelAgency.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<BaseItemData> Items { get; set; }
        public DbSet<ItemImageData> ItemImages { get; set; }

        public DbSet<BookingData> Bookings { get; set; }
        public DbSet<FavoriteData> Favorites { get; set; }

        public DbSet<SpaServiceData> SpaServices { get; set; }
        public DbSet<SpaBookingData> SpaBookings { get; set; }

        public DbSet<HotelRoomData> HotelRooms { get; set; }
        public DbSet<HotelBookingData> HotelBookings { get; set; }

        public DbSet<PlaceData> Places { get; set; }
        public DbSet<PackageData> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemImageData>()
                .HasOne(x => x.BaseItem)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.BaseItemId);
        }
    }
}