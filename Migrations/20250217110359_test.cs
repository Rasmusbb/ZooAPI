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
                    EnclosureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enclosures", x => x.EnclosureID);
                });

            migrationBuilder.CreateTable(
                name: "HealthJournals",
                columns: table => new
                {
                    HealthJournalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthJournals", x => x.HealthJournalID);
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
                name: "Animals",
                columns: table => new
                {
                    AnimalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statues = table.Column<int>(type: "int", nullable: false),
                    birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeathDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    specie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specialNeeds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthJournalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HealthJournalID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EnclosureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalID);
                    table.ForeignKey(
                        name: "FK_Animals_HealthJournals_HealthJournalID1",
                        column: x => x.HealthJournalID1,
                        principalTable: "HealthJournals",
                        principalColumn: "HealthJournalID");
                    table.ForeignKey(
                        name: "FK_Animals_enclosures_EnclosureID",
                        column: x => x.EnclosureID,
                        principalTable: "enclosures",
                        principalColumn: "EnclosureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZooKeepers",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnclosureID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooKeepers", x => new { x.UserID, x.EnclosureID });
                    table.ForeignKey(
                        name: "FK_ZooKeepers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZooKeepers_enclosures_EnclosureID",
                        column: x => x.EnclosureID,
                        principalTable: "enclosures",
                        principalColumn: "EnclosureID",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Animals_HealthJournalID1",
                table: "Animals",
                column: "HealthJournalID1");

            migrationBuilder.CreateIndex(
                name: "IX_ZooKeepers_EnclosureID",
                table: "ZooKeepers",
                column: "EnclosureID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "ZooKeepers");

            migrationBuilder.DropTable(
                name: "HealthJournals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "enclosures");
        }
    }
}
