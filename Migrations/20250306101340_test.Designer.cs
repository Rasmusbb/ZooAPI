﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooAPI.Data;

#nullable disable

namespace ZooAPI.Migrations
{
    [DbContext(typeof(ZooAPIContext))]
    [Migration("20250306101340_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnclosureStaff", b =>
                {
                    b.Property<Guid>("EnclosureID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EnclosureID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("EnclosureStaff");
                });

            modelBuilder.Entity("ZooAPI.models.Animal", b =>
                {
                    b.Property<Guid>("AnimalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DeathDay")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("EnclosureID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<Guid?>("HealthJournalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SpecieID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WellBeingReportID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("characteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("physicalID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("specialNeeds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("statues")
                        .HasColumnType("int");

                    b.HasKey("AnimalID");

                    b.HasIndex("EnclosureID");

                    b.HasIndex("HealthJournalID");

                    b.HasIndex("SpecieID");

                    b.HasIndex("WellBeingReportID");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("ZooAPI.models.Enclosure", b =>
                {
                    b.Property<Guid>("EnclosureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EnclosureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastFeeding")
                        .HasColumnType("datetime2");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<int>("Statues")
                        .HasColumnType("int");

                    b.HasKey("EnclosureID");

                    b.ToTable("enclosures");
                });

            modelBuilder.Entity("ZooAPI.models.HealthJournal", b =>
                {
                    b.Property<Guid>("HealthJournalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HealthJournalID");

                    b.ToTable("HealthJournals");
                });

            modelBuilder.Entity("ZooAPI.models.Specie", b =>
                {
                    b.Property<Guid>("SpecieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Gotindividuals")
                        .HasColumnType("bit");

                    b.Property<double>("SpaceNeed")
                        .HasColumnType("float");

                    b.Property<string>("SpeciesName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecieID");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("ZooAPI.models.Toys", b =>
                {
                    b.Property<Guid>("ToyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EnclosureID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ToyName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToyId");

                    b.HasIndex("EnclosureID");

                    b.ToTable("Toys");
                });

            modelBuilder.Entity("ZooAPI.models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<bool>("changedDefault")
                        .HasColumnType("bit");

                    b.Property<string>("mainArea")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = new Guid("334ee910-110a-4601-b939-08dd57c95921"),
                            Deleted = false,
                            Email = "admin",
                            Name = "admin",
                            Password = "9ffe44f9b962cc75df9112bf0010481d8a48f830a3c7d15f54b920845b1fde9c",
                            Phone = "None",
                            Role = 0,
                            changedDefault = false,
                            mainArea = "None"
                        });
                });

            modelBuilder.Entity("ZooAPI.models.WellBeingReport", b =>
                {
                    b.Property<Guid>("WellBeingReportID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("WellBeingReportID");

                    b.ToTable("WellBeingReports");
                });

            modelBuilder.Entity("EnclosureStaff", b =>
                {
                    b.HasOne("ZooAPI.models.Enclosure", null)
                        .WithMany()
                        .HasForeignKey("EnclosureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZooAPI.models.User", null)
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ZooAPI.models.Animal", b =>
                {
                    b.HasOne("ZooAPI.models.Enclosure", "Enclosure")
                        .WithMany("Animals")
                        .HasForeignKey("EnclosureID");

                    b.HasOne("ZooAPI.models.HealthJournal", "HealthJournal")
                        .WithMany()
                        .HasForeignKey("HealthJournalID");

                    b.HasOne("ZooAPI.models.Specie", "Specie")
                        .WithMany("Animals")
                        .HasForeignKey("SpecieID");

                    b.HasOne("ZooAPI.models.WellBeingReport", "wellBeingReport")
                        .WithMany()
                        .HasForeignKey("WellBeingReportID");

                    b.Navigation("Enclosure");

                    b.Navigation("HealthJournal");

                    b.Navigation("Specie");

                    b.Navigation("wellBeingReport");
                });

            modelBuilder.Entity("ZooAPI.models.Toys", b =>
                {
                    b.HasOne("ZooAPI.models.Enclosure", "Enclosure")
                        .WithMany("Toys")
                        .HasForeignKey("EnclosureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enclosure");
                });

            modelBuilder.Entity("ZooAPI.models.Enclosure", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Toys");
                });

            modelBuilder.Entity("ZooAPI.models.Specie", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
