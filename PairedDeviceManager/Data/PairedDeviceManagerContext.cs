using Microsoft.EntityFrameworkCore;
using PairedDeviceManager.Contract.Models;

namespace PairedDeviceManager.Data
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
