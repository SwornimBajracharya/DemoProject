using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDOperationAPI.Migrations
{
    public partial class Updatedprojectstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectStartDate",
                table: "Projects",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProjectEndDate",
                table: "Projects",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectStartDate",
                table: "Projects",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectEndDate",
                table: "Projects",
                nullable: true);
        }
    }
}
