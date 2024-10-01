using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HairSalon.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class changeColumnUserInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "UserInfos",
                newName: "Lastname");

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "UserInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "UserInfos");

            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "UserInfos",
                newName: "FullName");
        }
    }
}
