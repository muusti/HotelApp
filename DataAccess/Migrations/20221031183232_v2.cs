using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRooms_Customers_CustomerId",
                table: "CustomerRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRooms_Rooms_RoomId",
                table: "CustomerRooms");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRooms_Customers_CustomerId",
                table: "CustomerRooms",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRooms_Rooms_RoomId",
                table: "CustomerRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRooms_Customers_CustomerId",
                table: "CustomerRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerRooms_Rooms_RoomId",
                table: "CustomerRooms");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRooms_Customers_CustomerId",
                table: "CustomerRooms",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerRooms_Rooms_RoomId",
                table: "CustomerRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
