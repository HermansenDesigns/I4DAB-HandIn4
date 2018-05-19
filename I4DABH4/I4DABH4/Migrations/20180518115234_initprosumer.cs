using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace I4DABH4.Migrations
{
    public partial class initprosumer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prosumers",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prosumers", x => x.Address);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prosumers");
        }
    }
}
