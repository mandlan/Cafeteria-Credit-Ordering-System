using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafeteria_Credit___Ordering_System.Migrations
{
    /// <inheritdoc />
    public partial class AddModifyIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employees_EmployeeId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_EmployeeId1",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Order");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_MenuItemId",
                table: "OrderItem",
                column: "MenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employees_EmployeeId",
                table: "Order",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_MenuItems_MenuItemId",
                table: "OrderItem",
                column: "MenuItemId",
                principalTable: "MenuItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employees_EmployeeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_MenuItems_MenuItemId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_MenuItemId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_Order_EmployeeId",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId1",
                table: "Order",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employees_EmployeeId1",
                table: "Order",
                column: "EmployeeId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
