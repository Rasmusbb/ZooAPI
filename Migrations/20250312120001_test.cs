using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZooAPI.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
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
                    LastFeeding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statues = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enclosures", x => x.EnclosureID);
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
                name: "HealthJournals",
                columns: table => new
                {
                    HealthJournalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    lenght = table.Column<double>(type: "float", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthJournals", x => x.HealthJournalID);
                    table.ForeignKey(
                        name: "FK_HealthJournals_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WellBeingReports",
                columns: table => new
                {
                    WellBeingReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WellBeingReports", x => x.WellBeingReportID);
                    table.ForeignKey(
                        name: "FK_WellBeingReports_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Injurie",
                columns: table => new
                {
                    InjurieID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    injuie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthJournalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Injurie", x => x.InjurieID);
                    table.ForeignKey(
                        name: "FK_Injurie_HealthJournals_HealthJournalID",
                        column: x => x.HealthJournalID,
                        principalTable: "HealthJournals",
                        principalColumn: "HealthJournalID",
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

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Incident = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WellBeingReportID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentsID);
                    table.ForeignKey(
                        name: "FK_Incidents_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_WellBeingReports_WellBeingReportID",
                        column: x => x.WellBeingReportID,
                        principalTable: "WellBeingReports",
                        principalColumn: "WellBeingReportID");
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Medicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dose = table.Column<double>(type: "float", nullable: false),
                    unit = table.Column<int>(type: "int", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    expired = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthJournalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InjuieID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InjurieID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionID);
                    table.ForeignKey(
                        name: "FK_Prescription_HealthJournals_HealthJournalID",
                        column: x => x.HealthJournalID,
                        principalTable: "HealthJournals",
                        principalColumn: "HealthJournalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Injurie_InjurieID",
                        column: x => x.InjurieID,
                        principalTable: "Injurie",
                        principalColumn: "InjurieID");
                    table.ForeignKey(
                        name: "FK_Prescription_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "animalComments",
                columns: table => new
                {
                    CommentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animalComments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_animalComments_Animals_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animals",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Deleted", "Email", "Name", "Password", "Phone", "Role", "changedDefault", "mainArea" },
                values: new object[] { new Guid("334ee910-110a-4601-b939-08dd57c95921"), false, "admin", "admin", "9ffe44f9b962cc75df9112bf0010481d8a48f830a3c7d15f54b920845b1fde9c", "None", 0, false, "None" });

            migrationBuilder.CreateIndex(
                name: "IX_animalComments_AnimalID",
                table: "animalComments",
                column: "AnimalID");

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
                name: "IX_HealthJournals_UserID",
                table: "HealthJournals",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_UserID",
                table: "Incidents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_WellBeingReportID",
                table: "Incidents",
                column: "WellBeingReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Injurie_HealthJournalID",
                table: "Injurie",
                column: "HealthJournalID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_HealthJournalID",
                table: "Prescription",
                column: "HealthJournalID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_InjurieID",
                table: "Prescription",
                column: "InjurieID");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_UserID",
                table: "Prescription",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Toys_EnclosureID",
                table: "Toys",
                column: "EnclosureID");

            migrationBuilder.CreateIndex(
                name: "IX_WellBeingReports_UserID",
                table: "WellBeingReports",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animalComments");

            migrationBuilder.DropTable(
                name: "EnclosureStaff");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Injurie");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "WellBeingReports");

            migrationBuilder.DropTable(
                name: "enclosures");

            migrationBuilder.DropTable(
                name: "HealthJournals");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
