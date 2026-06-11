using Microsoft.EntityFrameworkCore;
using TravelAgency.Domains.Entities.Spa;
using TravelAgency.Domains.Entities.User;

namespace TravelAgency.DataAccess.Context
{
    public class SpaContext : DbContext
    {
        public DbSet<SpaSalonData> SpaSalons { get; set; }
        public DbSet<SpaServiceData> SpaServices { get; set; }
        public DbSet<SpaServiceImgData> SpaServiceImgs { get; set; }
        public DbSet<SpaBookingData> SpaBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpaServiceData>()
                .HasOne(x => x.SpaSalon)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.SpaSalonId);

            modelBuilder.Entity<SpaServiceImgData>()
                .HasOne(x => x.SpaService)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.SpaServiceId);

            modelBuilder.Entity<SpaBookingData>()
                .HasOne(x => x.SpaSalon)
                .WithMany()
                .HasForeignKey(x => x.SpaSalonId);
        }
    }
}