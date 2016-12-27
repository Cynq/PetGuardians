using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetGuardians.Data.Migrations
{
    public partial class OfferAddedOwnerAndOffers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Offers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OwnerId",
                table: "Offers",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfferId",
                table: "AspNetUsers",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_OwnerId",
                table: "Offers",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_OwnerId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_OwnerId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OfferId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "AspNetUsers");
        }
    }
}
