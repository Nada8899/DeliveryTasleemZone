using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasleemDelivery.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Client_ClientId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Delivery_DeliveryId",
                table: "Chat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chat",
                table: "Chat");

            migrationBuilder.RenameTable(
                name: "Chat",
                newName: "ClientChat");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_DeliveryId",
                table: "ClientChat",
                newName: "IX_ClientChat_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_ClientId",
                table: "ClientChat",
                newName: "IX_ClientChat_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientChat",
                table: "ClientChat",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DeliveryChat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryMsg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryMsgTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeliveryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryChat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryChat_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DeliveryChat_Delivery_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryChat_ClientId",
                table: "DeliveryChat",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryChat_DeliveryId",
                table: "DeliveryChat",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientChat_Client_ClientId",
                table: "ClientChat",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientChat_Delivery_DeliveryId",
                table: "ClientChat",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientChat_Client_ClientId",
                table: "ClientChat");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientChat_Delivery_DeliveryId",
                table: "ClientChat");

            migrationBuilder.DropTable(
                name: "DeliveryChat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientChat",
                table: "ClientChat");

            migrationBuilder.RenameTable(
                name: "ClientChat",
                newName: "Chat");

            migrationBuilder.RenameIndex(
                name: "IX_ClientChat_DeliveryId",
                table: "Chat",
                newName: "IX_Chat_DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientChat_ClientId",
                table: "Chat",
                newName: "IX_Chat_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chat",
                table: "Chat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Client_ClientId",
                table: "Chat",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Delivery_DeliveryId",
                table: "Chat",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
