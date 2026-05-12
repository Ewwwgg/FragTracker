using Microsoft.EntityFrameworkCore;
using FragTracker.Models;

namespace FragTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Реєстрація кібер-спортсменів як таблиці у базі даних
        public DbSet<ProPlayer> Players { get; set; }
    }
}
