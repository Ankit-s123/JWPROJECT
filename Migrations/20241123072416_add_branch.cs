using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class add_branch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_branch",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fb_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ins_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    li_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    you_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_branch", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_branch");
        }
    }
}
