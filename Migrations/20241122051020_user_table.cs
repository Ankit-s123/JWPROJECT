using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class user_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PCost",
                table: "tbl_project",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "tbl_user",
                columns: table => new
                {
                    UId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UPass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UStatus = table.Column<int>(type: "int", nullable: false),
                    UAdded_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.UId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_user");

            migrationBuilder.AlterColumn<int>(
                name: "PCost",
                table: "tbl_project",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
