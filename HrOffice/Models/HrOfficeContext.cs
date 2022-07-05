using Microsoft.EntityFrameworkCore;

namespace HrOffice.Models
{
    public class HrOfficeContext : DbContext
    {
        public HrOfficeContext(DbContextOptions<HrOfficeContext> options) : base(options)
        {

        }

        public DbSet<Emp> Employee { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
