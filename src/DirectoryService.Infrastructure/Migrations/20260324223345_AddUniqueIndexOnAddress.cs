using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevTasks.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexOnAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "locations");

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "district",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "mail_index",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "number_of_house",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "street",
                table: "locations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_locations_address_street_house",
                table: "locations",
                columns: new[] { "street", "number_of_house" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "city",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "country",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "district",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "mail_index",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "number_of_house",
                table: "locations");

            migrationBuilder.DropColumn(
                name: "street",
                table: "locations");

            migrationBuilder.DropIndex(
                name: "ix_locations_address_street_house",
                table: "locations");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "locations",
                type: "jsonb",
                nullable: false,
                defaultValue: "{}");
        }
    }
}
