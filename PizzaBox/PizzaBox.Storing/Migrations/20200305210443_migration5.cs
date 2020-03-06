using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class migration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CrustId = table.Column<long>(nullable: true),
                    SizeId = table.Column<long>(nullable: true),
                    ToppingId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Crust",
                columns: table => new
                {
                    CrustId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crust", x => x.CrustId);
                    table.ForeignKey(
                        name: "FK_Crust_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                    table.ForeignKey(
                        name: "FK_Size_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PizzaId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ToppingId);
                    table.ForeignKey(
                        name: "FK_Topping_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Crust",
                columns: new[] { "CrustId", "Name", "PizzaId", "Price" },
                values: new object[,]
                {
                    { 637190174828762899L, "Thin Crust", null, 2.00m },
                    { 637190174828763715L, "New York Style", null, 3.00m },
                    { 637190174828763743L, "Deep Dish", null, 4.00m }
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "CrustId", "Name", "SizeId", "ToppingId" },
                values: new object[] { 637190174828732536L, null, null, null, null });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "Name", "PizzaId", "Price" },
                values: new object[,]
                {
                    { 637190174828764332L, "Small", null, 7.00m },
                    { 637190174828764573L, "Medium", null, 10.00m },
                    { 637190174828764583L, "Large", null, 12.00m }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "ToppingId", "Name", "PizzaId", "Price" },
                values: new object[,]
                {
                    { 637190174828765157L, "Cheese", null, 0.25m },
                    { 637190174828765391L, "Sauce", null, 0.50m },
                    { 637190174828765405L, "Pepperonni", null, 0.75m },
                    { 637190174828765407L, "Bacon", null, 1.00m },
                    { 637190174828765409L, "Pinneapple", null, 1.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crust_PizzaId",
                table: "Crust",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_CrustId",
                table: "Pizza",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_SizeId",
                table: "Pizza",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_ToppingId",
                table: "Pizza",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_PizzaId",
                table: "Size",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Topping_PizzaId",
                table: "Topping",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Crust_CrustId",
                table: "Pizza",
                column: "CrustId",
                principalTable: "Crust",
                principalColumn: "CrustId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Size_SizeId",
                table: "Pizza",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Topping_ToppingId",
                table: "Pizza",
                column: "ToppingId",
                principalTable: "Topping",
                principalColumn: "ToppingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crust_Pizza_PizzaId",
                table: "Crust");

            migrationBuilder.DropForeignKey(
                name: "FK_Size_Pizza_PizzaId",
                table: "Size");

            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizza_PizzaId",
                table: "Topping");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Crust");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Topping");
        }
    }
}
