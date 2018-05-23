using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace I4DABH4.Migrations
{
    public partial class prosumerupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prosumers",
                table: "Prosumers");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Prosumers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "ProsumerId",
                table: "Prosumers",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "NetValue",
                table: "Prosumers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prosumers",
                table: "Prosumers",
                column: "ProsumerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Prosumers",
                table: "Prosumers");

            migrationBuilder.DropColumn(
                name: "ProsumerId",
                table: "Prosumers");

            migrationBuilder.DropColumn(
                name: "NetValue",
                table: "Prosumers");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Prosumers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prosumers",
                table: "Prosumers",
                column: "Address");
        }
    }
}
