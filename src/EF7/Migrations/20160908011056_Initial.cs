using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF7.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    IdRow = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.IdRow);
                });

            migrationBuilder.CreateTable(
                name: "Childs",
                columns: table => new
                {
                    IdRow = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentIdRow = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childs", x => x.IdRow);
                    table.ForeignKey(
                        name: "FK_Childs_Parents_ParentIdRow",
                        column: x => x.ParentIdRow,
                        principalTable: "Parents",
                        principalColumn: "IdRow",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    IdRow = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.IdRow);
                    table.ForeignKey(
                        name: "FK_Toys_Childs_IdRow",
                        column: x => x.IdRow,
                        principalTable: "Childs",
                        principalColumn: "IdRow",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Childs_ParentIdRow",
                table: "Childs",
                column: "ParentIdRow");

            migrationBuilder.CreateIndex(
                name: "IX_Toys_IdRow",
                table: "Toys",
                column: "IdRow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Childs");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
