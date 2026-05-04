using TravelAgency.Domains.Entities.Tour;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess;

namespace TravelAgency.DataAccess.Context
{
    public class TourContext : DbContext
    {
        public DbSet<TourData> Tours { get; set; }
        public DbSet<TourImgData> TourImgs { get; set; }
        public DbSet<CategoryData> Categories { get; set; }
        public DbSet<TourDescriptionData> Description { get; set; }
        public DbSet<DescriptionAdvanced> DescriptionAdvanced { get; set; }

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

            modelBuilder.Entity<TourData>()
                .HasOne(t => t.Description)
                .WithOne(d => d.Tour)
                .HasForeignKey<TourDescriptionData>(d => d.TourId);
        }

    }
}
