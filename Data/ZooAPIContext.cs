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
                .HasMany(E => E.Users)
                .WithMany(U => U.Enclosures)
                .UsingEntity(
                    "EnclosureStaff",
                    U => U.HasOne(typeof(User)).WithMany().HasForeignKey("UserID").HasPrincipalKey(nameof(User.UserID)),
                    E => E.HasOne(typeof(Enclosure)).WithMany().HasForeignKey("EnclosureID").HasPrincipalKey(nameof(Enclosure.EnclosureID)),
                    EU => EU.HasKey("EnclosureID", "UserID"));


            modelBuilder.Entity<Enclosure>()
                .HasMany(E => E.Species)
                .WithMany(S => S.Enclosures)
                .UsingEntity(
                "EnclosureSpecies",
                S => S.HasOne(typeof(Specie)).WithMany().HasForeignKey("SpecieID").HasPrincipalKey(nameof(Specie.SpecieID)),
                E => E.HasOne(typeof(Enclosure)).WithMany().HasForeignKey("EnclosureID").HasPrincipalKey(nameof(Enclosure.EnclosureID)),
                ES => ES.HasKey("EnclosureID", "SpecieID"));

            modelBuilder.Entity<User>(b =>
            {
                b.HasData(
                    new User {UserID = Guid.Parse("57622b09-2e10-49ff-c0d7-08dd4f427cf0"), Name = "BB",Email = "BB@AalborgZoo.dk",Phone = "55286715",Role = UserRole.Admin, mainArea = "Dinosaurs", Password= "7791b785456b7814357e881d7642b057533e0f6a148e959e5a8134df3535acbb" });
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> enclosures { get; set; }
        public DbSet<Specie> Species { get; set; }

        public DbSet<Toys> Toys { get; set; }
        public DbSet<HealthJournal> HealthJournals {  get; set; }

        public DbSet<WellBeingReport> WellBeingReports { get; set; }

    
    }
}
