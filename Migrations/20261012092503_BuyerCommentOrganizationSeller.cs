using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_backend.Migrations
{
    /// <inheritdoc />
    public partial class BuyerCommentOrganizationSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Buyer_BuyerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Seller_SellerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_OrgAddress_OrganizationAddressId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OrganizationAddressId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "OrganizationAddressId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "OrgAddress");

            migrationBuilder.DropColumn(
                name: "City",
                table: "OrgAddress");

            migrationBuilder.RenameColumn(
                name: "OrgainationURL",
                table: "Organizations",
                newName: "OrganizationURL");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "OrgAddress",
                newName: "OrgState");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "OrgAddress",
                newName: "OrgCountry");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "OrgAddress",
                newName: "OrgCity");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "OrgAddress",
                newName: "OrgAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "OrgAddress",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "Comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CommentsId",
                table: "Comments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrgAddress_OrganizationId",
                table: "OrgAddress",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentsId",
                table: "Comments",
                column: "CommentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Buyer_BuyerId",
                table: "Address",
                column: "BuyerId",
                principalTable: "Buyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Seller_SellerId",
                table: "Address",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentsId",
                table: "Comments",
                column: "CommentsId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrgAddress_Organizations_OrganizationId",
                table: "OrgAddress",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Buyer_BuyerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Seller_SellerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_OrgAddress_Organizations_OrganizationId",
                table: "OrgAddress");

            migrationBuilder.DropIndex(
                name: "IX_OrgAddress_OrganizationId",
                table: "OrgAddress");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentsId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "OrgAddress");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentsId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "OrganizationURL",
                table: "Organizations",
                newName: "OrgainationURL");

            migrationBuilder.RenameColumn(
                name: "OrgState",
                table: "OrgAddress",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "OrgCountry",
                table: "OrgAddress",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "OrgCity",
                table: "OrgAddress",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "OrgAddress",
                table: "OrgAddress",
                newName: "Country");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationAddressId",
                table: "Organizations",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "OrgAddress",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "OrgAddress",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrganizationAddressId",
                table: "Organizations",
                column: "OrganizationAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Buyer_BuyerId",
                table: "Address",
                column: "BuyerId",
                principalTable: "Buyer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Seller_SellerId",
                table: "Address",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_OrgAddress_OrganizationAddressId",
                table: "Organizations",
                column: "OrganizationAddressId",
                principalTable: "OrgAddress",
                principalColumn: "Id");
        }
    }
}
