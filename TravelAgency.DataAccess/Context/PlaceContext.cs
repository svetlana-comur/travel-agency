using Microsoft.EntityFrameworkCore;
using TravelAgency.Domains.Entities.Place;

namespace TravelAgency.DataAccess.Context
{
    public class PlaceContext : DbContext
    {
        public DbSet<CountryData> Countries { get; set; }
        public DbSet<PlaceData> Places { get; set; }

        public DbSet<PlaceImgData> PlaceImgs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaceData>()
                .HasOne(x => x.Country)
                .WithMany(x => x.Places)
                .HasForeignKey(x => x.CountryId);

            modelBuilder.Entity<CountryData>()
                .HasIndex(x => x.Name)
                .IsUnique();

            modelBuilder.Entity<PlaceImgData>()
                .HasOne(x => x.Place)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.PlaceId);
        }
    }
}