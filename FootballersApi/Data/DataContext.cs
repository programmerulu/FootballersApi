using FootballersApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballersApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Team> Teams { get; set; }

    }
}

