using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PhotoGallery_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API_SectionUploadPathData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    basePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    timeUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_SectionUploadPathData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "API_TaskReviewData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    task_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extractData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extractStartTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extractEndTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extractSta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isRunning = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_TaskReviewData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "API_UserAccessLevel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accessLevel = table.Column<int>(type: "int", nullable: false),
                    accessLevelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_UserAccessLevel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "API_TaskModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    taskid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    uploadPathDataid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_TaskModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_API_TaskModel_API_SectionUploadPathData_uploadPathDataid",
                        column: x => x.uploadPathDataid,
                        principalTable: "API_SectionUploadPathData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_TaskOrderData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectionUploadPathDataid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_TaskOrderData", x => x.id);
                    table.ForeignKey(
                        name: "FK_API_TaskOrderData_API_SectionUploadPathData_sectionUploadPathDataid",
                        column: x => x.sectionUploadPathDataid,
                        principalTable: "API_SectionUploadPathData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "API_Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    passwordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    userAccessLevelid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_API_Users_API_UserAccessLevel_userAccessLevelid",
                        column: x => x.userAccessLevelid,
                        principalTable: "API_UserAccessLevel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "API_UserAccessLevel",
                columns: new[] { "id", "accessLevel", "accessLevelName" },
                values: new object[,]
                {
                    { 1, 1, "SuperAdmin" },
                    { 2, 2, "Admin" },
                    { 3, 3, "User" },
                    { 4, 4, "Guest" },
                    { 99, 99, "Unknown" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_API_TaskModel_uploadPathDataid",
                table: "API_TaskModel",
                column: "uploadPathDataid");

            migrationBuilder.CreateIndex(
                name: "IX_API_TaskOrderData_sectionUploadPathDataid",
                table: "API_TaskOrderData",
                column: "sectionUploadPathDataid");

            migrationBuilder.CreateIndex(
                name: "IX_API_Users_userAccessLevelid",
                table: "API_Users",
                column: "userAccessLevelid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "API_TaskModel");

            migrationBuilder.DropTable(
                name: "API_TaskOrderData");

            migrationBuilder.DropTable(
                name: "API_TaskReviewData");

            migrationBuilder.DropTable(
                name: "API_Users");

            migrationBuilder.DropTable(
                name: "API_SectionUploadPathData");

            migrationBuilder.DropTable(
                name: "API_UserAccessLevel");
        }
    }
}
