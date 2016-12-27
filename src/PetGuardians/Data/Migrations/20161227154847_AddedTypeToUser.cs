using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using PetGuardians.Models.AccountViewModels;

namespace PetGuardians.Data.Migrations
{
    public partial class AddedTypeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: UserType.Owner);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");
        }
    }
}
