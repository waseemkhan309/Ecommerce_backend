using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddSellerAddressRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Buyer");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Seller",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Seller_AddressId",
                table: "Seller",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Address_AddressId",
                table: "Seller",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Address_AddressId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_AddressId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Seller");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Buyer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
