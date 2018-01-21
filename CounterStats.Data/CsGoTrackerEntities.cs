using System.Data.Entity;

namespace CounterStats.Data
{
    public class CsGoTrackerEntities : DbContext
    {
        public DbSet<Death> Deaths { get; set; }
        public DbSet<Kill> Kills { get; set; }
    }
}
