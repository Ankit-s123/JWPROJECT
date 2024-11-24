using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JWPROJECT.Migrations
{
    /// <inheritdoc />
    public partial class changesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PEdit_Date",
                table: "tbl_project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PEdit_Date",
                table: "tbl_project",
                type: "datetime2",
                nullable: true);
        }
    }
}
