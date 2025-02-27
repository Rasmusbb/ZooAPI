using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooAPI.Migrations
{
    /// <inheritdoc />
    public partial class animalsin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enclosures",
                columns: table => new
                {
                    EnclosureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnclosureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Statues = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enclosures", x => x.EnclosureID);
                });

            migrationBuilder.CreateTable(
                name: "HealthJournals",
                columns: table => new
                {
                    HealthJournalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthJournals", x => x.HealthJournalID);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    SpecieID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpeciesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpaceNeed = table.Column<double>(type: "float", nullable: false),
                    Gotindividuals = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.SpecieID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    mainArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    changedDefault = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "WellBeingReports",
                columns: table => new
                {
                    WellBeingReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellBeingReports", x => x.WellBeingReportID);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    ToyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnclosureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.ToyId);
                    table.ForeignKey(
                        name: "FK_Toys_enclosures_EnclosureID",
                        column: x => x.EnclosureID,
                        principalTable: "enclosures",
                        principalColumn: "EnclosureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnclosureStaff",
                columns: table => new
                {
                    EnclosureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnclosureStaff", x => new { x.EnclosureID, x.UserID });
                    table.ForeignKey(
                        name: "FK_EnclosureStaff_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnclosureStaff_enclosures_EnclosureID",
                        column: x => x.EnclosureID,
                        principalTable: "enclosures",
                        principalColumn: "EnclosureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    physicalID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    statues = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specialNeeds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnclosureID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HealthJournalID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WellBeingReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecieID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalID);
                    table.ForeignKey(
                        name: "FK_Animals_HealthJournals_HealthJournalID",
                        column: x => x.HealthJournalID,
                        principalTable: "HealthJournals",
                        principalColumn: "HealthJournalID");
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpecieID",
                        column: x => x.SpecieID,
                        principalTable: "Species",
                        principalColumn: "SpecieID");
                    table.ForeignKey(
                        name: "FK_Animals_WellBeingReports_WellBeingReportID",
                        column: x => x.WellBeingReportID,
                        principalTable: "WellBeingReports",
                        principalColumn: "WellBeingReportID");
                    table.ForeignKey(
                        name: "FK_Animals_enclosures_EnclosureID",
                        column: x => x.EnclosureID,
                        principalTable: "enclosures",
                        principalColumn: "EnclosureID");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Deleted", "Email", "Name", "Password", "Phone", "Role", "changedDefault", "mainArea" },
                values: new object[] { new Guid("57622b09-2e10-49ff-c0d7-08dd4f427cf0"), false, "BB@AalborgZoo.dk", "BB", "7791b785456b7814357e881d7642b057533e0f6a148e959e5a8134df3535acbb", "55286715", 0, false, "Dinosaurs" });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_EnclosureID",
                table: "Animals",
                column: "EnclosureID");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_HealthJournalID",
                table: "Animals",
                column: "HealthJournalID");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpecieID",
                table: "Animals",
                column: "SpecieID");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_WellBeingReportID",
                table: "Animals",
                column: "WellBeingReportID");

            migrationBuilder.CreateIndex(
                name: "IX_EnclosureStaff_UserID",
                table: "EnclosureStaff",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Toys_EnclosureID",
                table: "Toys",
                column: "EnclosureID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "EnclosureStaff");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "HealthJournals");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "WellBeingReports");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "enclosures");
        }
    }
}
