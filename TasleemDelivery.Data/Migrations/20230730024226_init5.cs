using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasleemDelivery.Data.Migrations
{
    /// <inheritdoc />
    public partial class init5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_AspNetUsers_ApplicationUserID",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Delivery_DeliveryId",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Skill_ApplicationUserID",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "Skill");

            migrationBuilder.RenameColumn(
                name: "DeliveryId",
                table: "Skill",
                newName: "DeliveryID");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_DeliveryId",
                table: "Skill",
                newName: "IX_Skill_DeliveryID");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryID",
                table: "Skill",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Delivery_DeliveryID",
                table: "Skill",
                column: "DeliveryID",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skill_Delivery_DeliveryID",
                table: "Skill");

            migrationBuilder.RenameColumn(
                name: "DeliveryID",
                table: "Skill",
                newName: "DeliveryId");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_DeliveryID",
                table: "Skill",
                newName: "IX_Skill_DeliveryId");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryId",
                table: "Skill",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserID",
                table: "Skill",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_ApplicationUserID",
                table: "Skill",
                column: "ApplicationUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_AspNetUsers_ApplicationUserID",
                table: "Skill",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_Delivery_DeliveryId",
                table: "Skill",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id");
        }
    }
}
