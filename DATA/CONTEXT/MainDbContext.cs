using DATA.EF_CORE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DATA.CONTEXT
{
    public class MainDbContext : DbContext
    {
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }

        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

    }
}