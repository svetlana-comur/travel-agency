using TravelAgency.Domains.Entities.Tour;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess;
using TravelAgency.Domains.Entities.Tour;

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
    }
}
