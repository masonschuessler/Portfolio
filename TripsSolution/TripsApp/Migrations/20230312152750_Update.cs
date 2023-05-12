using Microsoft.EntityFrameworkCore.Migrations;


namespace TripsApp.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "Destination", "ThingToDo1" },
                values: new object[] { "Denver", "Sight-see" });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2,
                columns: new[] { "Accommodation", "AccommodationEmail", "Destination", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { "Girlfriends' family", "", "Texas", "Vist inlaws", "East BBQ", "Drink Korean Wine" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 1,
                columns: new[] { "Destination", "ThingToDo1" },
                values: new object[] { "Boise", "Visit Tammy" });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "TripId",
                keyValue: 2,
                columns: new[] { "Accommodation", "AccommodationEmail", "Destination", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { "The Benson Hotel", "staff@bensonhotel.com", "Portland", "Go to Voodoo Doughnuts", "Walk in the rain", "Go to Powell's" });
        }
    }
}
