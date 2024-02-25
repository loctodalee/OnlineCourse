using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourse.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_action",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_action", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Permission",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Account = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifyToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_per_action",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ActionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_per_action", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_per_action_tbl_action_ActionId",
                        column: x => x.ActionId,
                        principalTable: "tbl_action",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_per_action_tbl_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "tbl_Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_per",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateTimes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_per", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_user_per_tbl_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "tbl_Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_user_per_tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_per_action_ActionId",
                table: "tbl_per_action",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_per_action_PermissionId",
                table: "tbl_per_action",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_per_PermissionId",
                table: "tbl_user_per",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_per_UserId",
                table: "tbl_user_per",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_per_action");

            migrationBuilder.DropTable(
                name: "tbl_user_per");

            migrationBuilder.DropTable(
                name: "tbl_action");

            migrationBuilder.DropTable(
                name: "tbl_Permission");

            migrationBuilder.DropTable(
                name: "tbl_User");
        }
    }
}
