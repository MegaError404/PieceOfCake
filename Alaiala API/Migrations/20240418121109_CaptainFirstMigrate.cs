using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PieceOfCake_API.Migrations
{
    /// <inheritdoc />
    public partial class CaptainFirstMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Captains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrimaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    PersonalIdentificationID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstPersonalIdentificationPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SecondPersonalIdentificationPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    RelativeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelativePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationShip = table.Column<int>(type: "int", nullable: false),
                    ActivetyStatus = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    WorkStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvitingCode = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Captains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Captains_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Captains_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaptainsLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OnmapLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptainsLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptainsLocations_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaptainsNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptainsNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptainsNotes_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaptainsNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptainsNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptainsNotifications_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaptainsSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptainsSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptainsSubscriptions_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaptainsSubscriptions_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaptainWorkflows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubmitType = table.Column<int>(type: "int", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptainWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptainWorkflows_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Captains_GovernorateId",
                table: "Captains",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Captains_VehicleID",
                table: "Captains",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsLocations_CaptainId",
                table: "CaptainsLocations",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsNotes_CaptainId",
                table: "CaptainsNotes",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsNotifications_CaptainId",
                table: "CaptainsNotifications",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsSubscriptions_CaptainId",
                table: "CaptainsSubscriptions",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsSubscriptions_SubscriptionId",
                table: "CaptainsSubscriptions",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainWorkflows_CaptainId",
                table: "CaptainWorkflows",
                column: "CaptainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaptainsLocations");

            migrationBuilder.DropTable(
                name: "CaptainsNotes");

            migrationBuilder.DropTable(
                name: "CaptainsNotifications");

            migrationBuilder.DropTable(
                name: "CaptainsSubscriptions");

            migrationBuilder.DropTable(
                name: "CaptainWorkflows");

            migrationBuilder.DropTable(
                name: "Captains");
        }
    }
}
