using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.Migrations
{
    public partial class OptionalSalesman : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Salesmen_SalesmanId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SalesmanId",
                schema: "dbo",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Salesmen_SalesmanId",
                schema: "dbo",
                table: "Orders",
                column: "SalesmanId",
                principalSchema: "dbo",
                principalTable: "Salesmen",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Salesmen_SalesmanId",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "SalesmanId",
                schema: "dbo",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Salesmen_SalesmanId",
                schema: "dbo",
                table: "Orders",
                column: "SalesmanId",
                principalSchema: "dbo",
                principalTable: "Salesmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
