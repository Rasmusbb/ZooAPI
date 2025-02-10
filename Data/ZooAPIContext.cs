using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ZooAPI.models;

namespace ZooAPI.Data
{
    public class ZooAPIContext : DbContext
    {
        public ZooAPIContext (DbContextOptions<ZooAPIContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ZooKeeper>()
                .HasKey(zk => new { zk.UserID, zk.EnclosureID });

            modelBuilder.Entity<ZooKeeper>()
                .HasOne(zk => zk.User)
                .WithMany(u => u.Enclosures)
                .HasForeignKey(zk => zk.UserID);

            modelBuilder.Entity<ZooKeeper>()
                .HasOne(zk => zk.Enclosure)
                .WithMany(e => e.ZooKeepers)
                .HasForeignKey(zk => zk.EnclosureID);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> enclosures { get; set; }

        public DbSet<ZooKeeper> ZooKeepers { get; set; }

        public DbSet<HealthJournal> HealthJournals {  get; set; }

    
    }
}
