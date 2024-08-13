﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project.Migrations
{
    /// <inheritdoc />
    public partial class relationshipUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategorieId",
                table: "Products",
                column: "CategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorias_CategorieId",
                table: "Products",
                column: "CategorieId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorias_CategorieId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategorieId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Products");
        }
    }
}
