using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks_usingEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "divisions",
                columns: table => new
                {
                    DIVID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divisions", x => x.DIVID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Projectbudjet = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectTeamSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PID);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ename = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    EMobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DIVID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EID);
                    table.ForeignKey(
                        name: "FK_employees_divisions_DIVID",
                        column: x => x.DIVID,
                        principalTable: "divisions",
                        principalColumn: "DIVID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    EPID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PID = table.Column<long>(type: "bigint", nullable: false),
                    EID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.EPID);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_PID",
                        column: x => x.PID,
                        principalTable: "Projects",
                        principalColumn: "PID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_employees_EID",
                        column: x => x.EID,
                        principalTable: "employees",
                        principalColumn: "EID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EID",
                table: "EmployeeProjects",
                column: "EID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_PID",
                table: "EmployeeProjects",
                column: "PID");

            migrationBuilder.CreateIndex(
                name: "IX_employees_DIVID",
                table: "employees",
                column: "DIVID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "divisions");
        }
    }
}
