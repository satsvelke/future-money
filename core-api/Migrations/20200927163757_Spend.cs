using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Spend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spent",
                columns: table => new
                {
                    SpendId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CategoryId1 = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    MoneySpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spent", x => x.SpendId);
                    table.ForeignKey(
                        name: "FK_Spent_SpendCategories_CategoryId1",
                        column: x => x.CategoryId1,
                        principalTable: "SpendCategories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spent_CategoryId1",
                table: "Spent",
                column: "CategoryId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spent");
        }
    }
}
