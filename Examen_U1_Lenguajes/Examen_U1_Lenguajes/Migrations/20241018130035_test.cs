using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_U1_Lenguajes.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission_types",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_titles",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    department_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_titles", x => x.id);
                    table.ForeignKey(
                        name: "FK_job_titles_departments_department_id",
                        column: x => x.department_id,
                        principalSchema: "dbo",
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    permission_type_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    is_approved = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_by = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    updated_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_requests_permission_types_permission_type_id",
                        column: x => x.permission_type_id,
                        principalSchema: "dbo",
                        principalTable: "permission_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_titles_department_id",
                schema: "dbo",
                table: "job_titles",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_requests_permission_type_id",
                schema: "dbo",
                table: "requests",
                column: "permission_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "job_titles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "requests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "departments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "permission_types",
                schema: "dbo");
        }
    }
}
