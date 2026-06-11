using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess;
using TravelAgency.Domains.Entities.Refs;
using TravelAgency.Domains.Entities.Tour;
using TravelAgency.Domains.Entities.User;

namespace TravelAgency.DataAccess.Context
{
    public class TourContext : DbContext
    {
        public DbSet<TourData> Tours { get; set; }
        public DbSet<TourImgData> TourImgs { get; set; }
        public DbSet<CategoryData> Categories { get; set; }

        public DbSet<TourBookingData> TourBookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourData>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tours)
                .HasForeignKey(t => t.CategoryId);

            modelBuilder.Entity<TourImgData>()
                .HasOne(i => i.Tour)
                .WithMany(t => t.Images)
                .HasForeignKey(i => i.TourId);

            modelBuilder.Entity<CategoryData>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<TourBookingData>()
                .HasOne(b => b.Tour)
                .WithMany()
                .HasForeignKey(b => b.TourId);

        }

        public override int SaveChanges()
        {
            var now = DateTime.UtcNow;

            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is SharedFields &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (SharedFields)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = now;
                }

                entity.UpdatedAt = now;
            }


            var affectedTourIdsFromImages = ChangeTracker.Entries<TourImgData>()
                .Where(e =>
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified ||
                    e.State == EntityState.Deleted)
                .Select(e => e.Entity.TourId)
                .ToList();

            var affectedTourIds = affectedTourIdsFromImages
                .Distinct()
                .ToList();

            if (affectedTourIds.Any())
            {
                var tours = Tours
                    .Where(t => affectedTourIds.Contains(t.Id))
                    .ToList();

                foreach (var tour in tours)
                {
                    tour.UpdatedAt = now;
                }
            }

            return base.SaveChanges();
        }
    }
}