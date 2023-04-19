using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizzApp.Migrations
{
    /// <inheritdoc />
    public partial class FixedOneToOneUAtoUC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserCredentialsId",
                table: "UsersAccounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCredentialsId",
                table: "UsersAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
