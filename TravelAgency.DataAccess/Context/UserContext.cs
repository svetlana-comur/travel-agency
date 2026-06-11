using TravelAgency.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace TravelAgency.DataAccess.Context
{
    public class UserContext : DbContext
    {

        public DbSet<UserData> Users { get; set; }

        public DbSet<FavoriteData> Favorites { get; set; }

        public DbSet<EmailToken> EmailTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSession.ConnectionStrings);
        }
    }
}
