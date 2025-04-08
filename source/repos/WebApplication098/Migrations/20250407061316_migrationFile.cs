using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication098.Migrations
{
    /// <inheritdoc />
    public partial class migrationFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    Organization_id = table.Column<int>(type: "integer", nullable: false),
                    OrganizationInfoid = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id);
                    table.ForeignKey(
                        name: "FK_Admin_Organizations_OrganizationInfoid",
                        column: x => x.OrganizationInfoid,
                        principalTable: "Organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    project_name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    startDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Organization_id = table.Column<int>(type: "integer", nullable: false),
                    OrganizationInfoid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.project_id);
                    table.ForeignKey(
                        name: "FK_Project_Organizations_OrganizationInfoid",
                        column: x => x.OrganizationInfoid,
                        principalTable: "Organizations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestPlan",
                columns: table => new
                {
                    TestPlan_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    objective = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    strategy = table.Column<string>(type: "text", nullable: false),
                    project_id = table.Column<int>(type: "integer", nullable: false),
                    project_infoproject_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestPlan", x => x.TestPlan_id);
                    table.ForeignKey(
                        name: "FK_TestPlan_Project_project_infoproject_id",
                        column: x => x.project_infoproject_id,
                        principalTable: "Project",
                        principalColumn: "project_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSuite",
                columns: table => new
                {
                    testSuite_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TestPlanId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSuite", x => x.testSuite_id);
                    table.ForeignKey(
                        name: "FK_TestSuite_TestPlan_TestPlanId",
                        column: x => x.TestPlanId,
                        principalTable: "TestPlan",
                        principalColumn: "TestPlan_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    steps = table.Column<string>(type: "text", nullable: false),
                    IsAutomated = table.Column<bool>(type: "boolean", nullable: false),
                    TestSuite_id = table.Column<int>(type: "integer", nullable: false),
                    TestSuite_infotestSuite_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestCases_TestSuite_TestSuite_infotestSuite_id",
                        column: x => x.TestSuite_infotestSuite_id,
                        principalTable: "TestSuite",
                        principalColumn: "testSuite_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSteps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    action = table.Column<string>(type: "text", nullable: false),
                    ExpectedResult = table.Column<string>(type: "text", nullable: false),
                    actualResult = table.Column<string>(type: "text", nullable: false),
                    TestCase_id = table.Column<int>(type: "integer", nullable: false),
                    testCase_infoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSteps", x => x.id);
                    table.ForeignKey(
                        name: "FK_TestSteps_TestCases_testCase_infoId",
                        column: x => x.testCase_infoId,
                        principalTable: "TestCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_OrganizationInfoid",
                table: "Admin",
                column: "OrganizationInfoid");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrganizationInfoid",
                table: "Project",
                column: "OrganizationInfoid");

            migrationBuilder.CreateIndex(
                name: "IX_TestCases_TestSuite_infotestSuite_id",
                table: "TestCases",
                column: "TestSuite_infotestSuite_id");

            migrationBuilder.CreateIndex(
                name: "IX_TestPlan_project_infoproject_id",
                table: "TestPlan",
                column: "project_infoproject_id");

            migrationBuilder.CreateIndex(
                name: "IX_TestSteps_testCase_infoId",
                table: "TestSteps",
                column: "testCase_infoId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSuite_TestPlanId",
                table: "TestSuite",
                column: "TestPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "TestSteps");

            migrationBuilder.DropTable(
                name: "TestCases");

            migrationBuilder.DropTable(
                name: "TestSuite");

            migrationBuilder.DropTable(
                name: "TestPlan");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
