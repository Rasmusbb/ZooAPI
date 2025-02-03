using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZooAPI.models;

namespace ZooAPI.Data
{
    public class ZooAPIContext : DbContext
    {
        public ZooAPIContext (DbContextOptions<ZooAPIContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
    }
}
