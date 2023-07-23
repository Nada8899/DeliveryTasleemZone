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
                name: "FK_Admin_AspNetUsers_Id",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Client_ClientId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Delivery_DeliveryId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_AspNetUsers_Id",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_AspNetUsers_Id",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationLevel_Delivery_DeliveryID",
                table: "EducationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Delivery_DeliveryId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Location_LocationId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Languge_AspNetUsers_ApplicationUserID",
                table: "Languge");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Delivery_DeliveryId",
                table: "Proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Job_JobID",
                table: "Proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Job_JobId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_Delivery_DeliveryId",
                table: "SavedJob");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_Job_JobId",
                table: "SavedJob");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_AspNetUsers_ApplicationUserID",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_SubAdmin_AspNetUsers_Id",
                table: "SubAdmin");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfileImg",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_Id",
                table: "Admin",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Client_AspNetUsers_Id",
                table: "Client",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_AspNetUsers_Id",
                table: "Delivery",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EducationLevel_Delivery_DeliveryID",
                table: "EducationLevel",
                column: "DeliveryID",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Delivery_DeliveryId",
                table: "Job",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Location_LocationId",
                table: "Job",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Languge_AspNetUsers_ApplicationUserID",
                table: "Languge",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Delivery_DeliveryId",
                table: "Proposal",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Job_JobID",
                table: "Proposal",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Job_JobId",
                table: "Review",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_Delivery_DeliveryId",
                table: "SavedJob",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_Job_JobId",
                table: "SavedJob",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_AspNetUsers_ApplicationUserID",
                table: "Skill",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SubAdmin_AspNetUsers_Id",
                table: "SubAdmin",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AspNetUsers_Id",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Client_ClientId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Chat_Delivery_DeliveryId",
                table: "Chat");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_AspNetUsers_Id",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_AspNetUsers_Id",
                table: "Delivery");

            migrationBuilder.DropForeignKey(
                name: "FK_EducationLevel_Delivery_DeliveryID",
                table: "EducationLevel");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Delivery_DeliveryId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Location_LocationId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Languge_AspNetUsers_ApplicationUserID",
                table: "Languge");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Delivery_DeliveryId",
                table: "Proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposal_Job_JobID",
                table: "Proposal");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Job_JobId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_Delivery_DeliveryId",
                table: "SavedJob");

            migrationBuilder.DropForeignKey(
                name: "FK_SavedJob_Job_JobId",
                table: "SavedJob");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_AspNetUsers_ApplicationUserID",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_SubAdmin_AspNetUsers_Id",
                table: "SubAdmin");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfileImg",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AspNetUsers_Id",
                table: "Admin",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Client_ClientId",
                table: "Chat",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chat_Delivery_DeliveryId",
                table: "Chat",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_AspNetUsers_Id",
                table: "Client",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_AspNetUsers_Id",
                table: "Delivery",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EducationLevel_Delivery_DeliveryID",
                table: "EducationLevel",
                column: "DeliveryID",
                principalTable: "Delivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Client_ClientId",
                table: "Job",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Delivery_DeliveryId",
                table: "Job",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Location_LocationId",
                table: "Job",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languge_AspNetUsers_ApplicationUserID",
                table: "Languge",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Delivery_DeliveryId",
                table: "Proposal",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposal_Job_JobID",
                table: "Proposal",
                column: "JobID",
                principalTable: "Job",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Client_ClientId",
                table: "Review",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Job_JobId",
                table: "Review",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_Delivery_DeliveryId",
                table: "SavedJob",
                column: "DeliveryId",
                principalTable: "Delivery",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedJob_Job_JobId",
                table: "SavedJob",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_AspNetUsers_ApplicationUserID",
                table: "Skill",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubAdmin_AspNetUsers_Id",
                table: "SubAdmin",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
