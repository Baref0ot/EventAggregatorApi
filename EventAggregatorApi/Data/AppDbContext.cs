using Microsoft.EntityFrameworkCore;
using EventAggregatorApi.Models;

namespace EventAggregatorApi.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EventBriteEvent> EventBriteEvents { get; set; }

    }// end class
}
