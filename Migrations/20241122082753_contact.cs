using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_contact",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMessage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_contact", x => x.CId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_contact");
        }
    }
}
