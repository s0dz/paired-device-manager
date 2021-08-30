using Microsoft.EntityFrameworkCore;
using PairedDeviceManager.Api.Models;

namespace PairedDeviceManager.Api.Data
{
    public class PairedDeviceManagerContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Dwelling> Dwellings { get; set; }
        public DbSet<Hub> Hubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        }
    }
}
