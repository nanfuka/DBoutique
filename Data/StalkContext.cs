using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StalkContext : DbContext
    {
        public Dbset<Stalk> Stolk { get; set; }

    }
}