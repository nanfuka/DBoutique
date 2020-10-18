using Microsoft.EntityFrameworkCore;

using Models;

namespace Data
{
    public class StalkContext : DbContext
    {
        public StalkContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Stalk> Stolk { get; set; }

    }
}