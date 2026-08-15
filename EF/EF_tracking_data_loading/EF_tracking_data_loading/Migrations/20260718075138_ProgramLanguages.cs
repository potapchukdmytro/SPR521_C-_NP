using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Relationships_seeder.Migrations
{
    /// <inheritdoc />
    public partial class ProgramLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProgramLanguages",
                columns: table => new
                {
                    ProgramLanguagesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgramLanguages", x => new { x.ProgramLanguagesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserProgramLanguages_ProgramLanguages_ProgramLanguagesId",
                        column: x => x.ProgramLanguagesId,
                        principalTable: "ProgramLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProgramLanguages_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProgramLanguages_UsersId",
                table: "UserProgramLanguages",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProgramLanguages");

            migrationBuilder.DropTable(
                name: "ProgramLanguages");
        }
    }
}
