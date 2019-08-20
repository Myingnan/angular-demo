using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Base");

            migrationBuilder.EnsureSchema(
                name: "base");

            migrationBuilder.CreateTable(
                name: "SysMenu",
                schema: "Base",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(36)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CreateBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    Path = table.Column<string>(type: "varchar(50)", nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", nullable: true),
                    Component = table.Column<string>(type: "varchar(100)", nullable: true),
                    Icon = table.Column<string>(type: "varchar(50)", nullable: true),
                    ParentID = table.Column<string>(type: "varchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysMenu_SysMenu_ParentID",
                        column: x => x.ParentID,
                        principalSchema: "Base",
                        principalTable: "SysMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                schema: "Base",
                columns: table => new
                {
                    RoleID = table.Column<string>(type: "varchar(36)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CreateBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    RoleName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SysUser",
                schema: "Base",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(36)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    CreateBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdateBy = table.Column<string>(type: "varchar(20)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReallyName = table.Column<string>(type: "varchar(50)", nullable: true),
                    MobilePhone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    DepartmentID = table.Column<string>(type: "varchar(36)", nullable: true),
                    IsEnable = table.Column<bool>(nullable: false),
                    Remark = table.Column<string>(type: "varchar(200)", nullable: true),
                    PermissionRange = table.Column<string>(type: "varchar(100)", nullable: true),
                    ContractType = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUser", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "SysRoleMenuRelation",
                schema: "base",
                columns: table => new
                {
                    RoleID = table.Column<string>(nullable: false),
                    MenuID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRoleMenuRelation", x => new { x.RoleID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_SysRoleMenuRelation_SysMenu_MenuID",
                        column: x => x.MenuID,
                        principalSchema: "Base",
                        principalTable: "SysMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysRoleMenuRelation_SysRole_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "Base",
                        principalTable: "SysRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SysUserRoleRelation",
                schema: "base",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    RoleID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysUserRoleRelation", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_SysUserRoleRelation_SysRole_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "Base",
                        principalTable: "SysRole",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SysUserRoleRelation_SysUser_UserID",
                        column: x => x.UserID,
                        principalSchema: "Base",
                        principalTable: "SysUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysRoleMenuRelation_MenuID",
                schema: "base",
                table: "SysRoleMenuRelation",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_SysUserRoleRelation_RoleID",
                schema: "base",
                table: "SysUserRoleRelation",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SysMenu_ParentID",
                schema: "Base",
                table: "SysMenu",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysRoleMenuRelation",
                schema: "base");

            migrationBuilder.DropTable(
                name: "SysUserRoleRelation",
                schema: "base");

            migrationBuilder.DropTable(
                name: "SysMenu",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "SysRole",
                schema: "Base");

            migrationBuilder.DropTable(
                name: "SysUser",
                schema: "Base");
        }
    }
}
