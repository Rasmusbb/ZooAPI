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

            modelBuilder.Entity<HealthJournal>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserID)
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>(b =>
            {
                b.HasData(
                    new User {UserID = Guid.Parse("334EE910-110A-4601-B939-08DD57C95921"), Name = "admin",Email = "admin",Phone = "None",Role = UserRole.Admin, mainArea = "None", Password= "9ffe44f9b962cc75df9112bf0010481d8a48f830a3c7d15f54b920845b1fde9c" });
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> enclosures { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Incidents> Incidents { get; set; }
        public DbSet<AnimalComments> animalComments {get; set;}
        public DbSet<Toys> Toys { get; set; }
        public DbSet<HealthJournal> HealthJournals {  get; set; }

        public DbSet<WellBeingReport> WellBeingReports { get; set; }

    
    }
}
