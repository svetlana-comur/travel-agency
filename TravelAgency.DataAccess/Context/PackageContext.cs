using Microsoft.EntityFrameworkCore;
using TravelAgency.Domains.Entities.Package;

namespace TravelAgency.DataAccess.Context
{
    public class PackageContext : DbContext
    {
        public DbSet<PackageData> Packages { get; set; }
        public DbSet<PackageImgData> PackageImgs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PackageImgData>()
                .HasOne(x => x.Package)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.PackageId);
        }
    }
}