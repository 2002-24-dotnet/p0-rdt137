using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaType",
                columns: table => new
                {
                    TypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    Crust = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaType", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Location);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location1 = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Store_Location1",
                        column: x => x.Location1,
                        principalTable: "Store",
                        principalColumn: "Location",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaTypeTypeId = table.Column<long>(nullable: true),
                    OrderId = table.Column<long>(nullable: true),
                    SizeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                    table.ForeignKey(
                        name: "FK_Pizza_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_PizzaType_PizzaTypeTypeId",
                        column: x => x.PizzaTypeTypeId,
                        principalTable: "PizzaType",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PizzaType",
                columns: new[] { "TypeId", "Cost", "Crust", "Name" },
                values: new object[,]
                {
                    { 1L, 8.00m, "Crust1", "PepPizza" },
                    { 2L, 7.00m, "Crust121", "CheesePizza" },
                    { 3L, 10.00m, "Crust432", "PinBacPizza" }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "Cost", "Name" },
                values: new object[,]
                {
                    { 1L, 12.00m, "Large" },
                    { 2L, 10.00m, "Medium" },
                    { 3L, 8.00m, "Small" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                column: "Location",
                values: new object[]
                {
                    "Cooper",
                    "S West St"
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Password", "UserType" },
                values: new object[,]
                {
                    { "user1", "123", "Customer" },
                    { "user2", "234", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Location1",
                table: "Order",
                column: "Location1");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderId",
                table: "Pizza",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_PizzaTypeTypeId",
                table: "Pizza",
                column: "PizzaTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PizzaType");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
