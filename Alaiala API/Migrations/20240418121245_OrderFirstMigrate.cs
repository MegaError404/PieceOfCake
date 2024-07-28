using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alaiala_API.Migrations
{
    /// <inheritdoc />
    public partial class OrderFirstMigrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcceptedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatingDateTime = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: false),
                    AcceptingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveringCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverLoadCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcceptedOrders_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcceptedOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AcceptedOrders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AcceptedOrders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DeliveredOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveringDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveringCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverLoadCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProofingPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveredOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveredOrders_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveredOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveredOrders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeliveredOrders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InprogressOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveringCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverLoadCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InprogressOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InprogressOrders_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InprogressOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InprogressOrders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InprogressOrders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "NewOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveringCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverLoadCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewOrders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewOrders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderCancellationReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderCancellationReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersComplaints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComplaintText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MerchantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersComplaints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdersComplaints_Merchants_MerchantId",
                        column: x => x.MerchantId,
                        principalTable: "Merchants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RedirectedOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveringCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverLoadCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectedOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedirectedOrders_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RedirectedOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RedirectedOrders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RedirectedOrders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CaptainsCanceledOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveringDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveringCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverLoadCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptainsCanceledOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptainsCanceledOrders_Captains_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "Captains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CaptainsCanceledOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaptainsCanceledOrders_OrderCancellationReasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "OrderCancellationReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaptainsCanceledOrders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaptainsCanceledOrders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MerchantsCanceledOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    CreatingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelingDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveringCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OverLoadCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MerchantsCanceledOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MerchantsCanceledOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MerchantsCanceledOrders_OrderCancellationReasons_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "OrderCancellationReasons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MerchantsCanceledOrders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MerchantsCanceledOrders_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedOrders_CaptainId",
                table: "AcceptedOrders",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedOrders_CustomerId",
                table: "AcceptedOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedOrders_StoreId",
                table: "AcceptedOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedOrders_VehicleID",
                table: "AcceptedOrders",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsCanceledOrders_CaptainId",
                table: "CaptainsCanceledOrders",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsCanceledOrders_CustomerId",
                table: "CaptainsCanceledOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsCanceledOrders_ReasonId",
                table: "CaptainsCanceledOrders",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsCanceledOrders_StoreId",
                table: "CaptainsCanceledOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainsCanceledOrders_VehicleID",
                table: "CaptainsCanceledOrders",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveredOrders_CaptainId",
                table: "DeliveredOrders",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveredOrders_CustomerId",
                table: "DeliveredOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveredOrders_StoreId",
                table: "DeliveredOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveredOrders_VehicleID",
                table: "DeliveredOrders",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_InprogressOrders_CaptainId",
                table: "InprogressOrders",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_InprogressOrders_CustomerId",
                table: "InprogressOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InprogressOrders_StoreId",
                table: "InprogressOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_InprogressOrders_VehicleID",
                table: "InprogressOrders",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantsCanceledOrders_CustomerId",
                table: "MerchantsCanceledOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantsCanceledOrders_ReasonId",
                table: "MerchantsCanceledOrders",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantsCanceledOrders_StoreId",
                table: "MerchantsCanceledOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MerchantsCanceledOrders_VehicleID",
                table: "MerchantsCanceledOrders",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_NewOrders_CustomerId",
                table: "NewOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_NewOrders_StoreId",
                table: "NewOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_NewOrders_VehicleID",
                table: "NewOrders",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersComplaints_MerchantId",
                table: "OrdersComplaints",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectedOrders_CaptainId",
                table: "RedirectedOrders",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectedOrders_CustomerId",
                table: "RedirectedOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectedOrders_StoreId",
                table: "RedirectedOrders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_RedirectedOrders_VehicleID",
                table: "RedirectedOrders",
                column: "VehicleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedOrders");

            migrationBuilder.DropTable(
                name: "CaptainsCanceledOrders");

            migrationBuilder.DropTable(
                name: "DeliveredOrders");

            migrationBuilder.DropTable(
                name: "InprogressOrders");

            migrationBuilder.DropTable(
                name: "MerchantsCanceledOrders");

            migrationBuilder.DropTable(
                name: "NewOrders");

            migrationBuilder.DropTable(
                name: "OrdersComplaints");

            migrationBuilder.DropTable(
                name: "RedirectedOrders");

            migrationBuilder.DropTable(
                name: "OrderCancellationReasons");
        }
    }
}
