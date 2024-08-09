using Microsoft.EntityFrameworkCore;
using OT.Shared;

namespace OT.Api.DataContext
{
    public class OTApiSQLContext : DbContext
    {
        public OTApiSQLContext(DbContextOptions<OTApiSQLContext> options) : base(options)
        {
        }

        public DbSet<VehicleColor> vehicleColors { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public  DbSet<ShopClient> ShopClients { get; set; }
        public DbSet<VehicleDetails> VehicleDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
