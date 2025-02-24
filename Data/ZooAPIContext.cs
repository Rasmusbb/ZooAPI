using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
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

            modelBuilder.Entity<Enclosure>()
                .HasOne(e => e.User)
                .WithMany(z => z.Enclosures)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Enclosure>()
                .HasOne(e => e.Species)
                .WithMany(s => s.enclosures)
                .HasForeignKey(e => e.SpeciesID);











            modelBuilder.Entity<User>(b =>
            {
                b.HasData(
                    new User {UserID = Guid.Parse("57622b09-2e10-49ff-c0d7-08dd4f427cf0"), Name = "BB",Email = "BB@AalborgZoo.dk",Phone = "55286715",Role = UserRole.Admin, mainArea = "Dinosaurs", Password= "7791b785456b7814357e881d7642b057533e0f6a148e959e5a8134df3535acbb" });
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> enclosures { get; set; }
        public DbSet<Species> Species { get; set; }


        public DbSet<HealthJournal> HealthJournals {  get; set; }

        public DbSet<WellBeingReport> WellBeingReports { get; set; }

    
    }
}
