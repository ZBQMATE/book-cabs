using Microsoft.EntityFrameworkCore.Migrations;

namespace CabBooking.Infrastructure.Migrations
{
    public partial class add2Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToPlace",
                table: "BookingHistory",
                newName: "ToPlaceId");

            migrationBuilder.RenameColumn(
                name: "FromPlace",
                table: "BookingHistory",
                newName: "FromPlaceId");

            migrationBuilder.RenameColumn(
                name: "ToPlace",
                table: "Booking",
                newName: "ToPlaceId");

            migrationBuilder.RenameColumn(
                name: "FromPlace",
                table: "Booking",
                newName: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistory_FromPlaceId",
                table: "BookingHistory",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistory_ToPlaceId",
                table: "BookingHistory",
                column: "ToPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FromPlaceId",
                table: "Booking",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ToPlaceId",
                table: "Booking",
                column: "ToPlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Place_FromPlaceId",
                table: "Booking",
                column: "FromPlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Place_ToPlaceId",
                table: "Booking",
                column: "ToPlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_Place_FromPlaceId",
                table: "BookingHistory",
                column: "FromPlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_Place_ToPlaceId",
                table: "BookingHistory",
                column: "ToPlaceId",
                principalTable: "Place",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Place_FromPlaceId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Place_ToPlaceId",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_Place_FromPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_Place_ToPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropIndex(
                name: "IX_BookingHistory_FromPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropIndex(
                name: "IX_BookingHistory_ToPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropIndex(
                name: "IX_Booking_FromPlaceId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ToPlaceId",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "ToPlaceId",
                table: "BookingHistory",
                newName: "ToPlace");

            migrationBuilder.RenameColumn(
                name: "FromPlaceId",
                table: "BookingHistory",
                newName: "FromPlace");

            migrationBuilder.RenameColumn(
                name: "ToPlaceId",
                table: "Booking",
                newName: "ToPlace");

            migrationBuilder.RenameColumn(
                name: "FromPlaceId",
                table: "Booking",
                newName: "FromPlace");
        }
    }
}
