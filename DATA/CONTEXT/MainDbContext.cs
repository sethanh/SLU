using DATA.EF_CORE;
using DATA.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.CONTEXT
{
    public class MainDbContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopBranch> ShopBranchs { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccountDevice> CustomerAccountDevices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingDetail> BookingsDetails { get; set; }
        public DbSet<BookingDetailObject> BookingDetailObjects { get; set; }
        public DbSet<AppModule> AppModules { get; set; }
        public DbSet<AppModulePermission> AppModulePermissions { get; set; }
        
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder = GlobalQueryFillter.BuilCustomFillter(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void ResetTracker()
        {
            var entries = this.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                entry.State = EntityState.Detached;
            }
        }

    }
}