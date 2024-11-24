using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class table_P_U : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_project",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCost = table.Column<int>(type: "int", nullable: false),
                    PDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PAdd_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PEdit_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    PStatus = table.Column<int>(type: "int", nullable: false),
                    PZip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDocument = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_project", x => x.PId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_project");
        }
    }
}
