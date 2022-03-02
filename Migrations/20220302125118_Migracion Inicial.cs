using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nomina_Empleados_Leng.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<long>(type: "INTEGER", nullable: false),
                    Departamento = table.Column<string>(type: "TEXT", nullable: false),
                    Puesto = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Nominas",
                columns: table => new
                {
                    NominaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalarioMensual = table.Column<double>(type: "REAL", nullable: false),
                    HorasExtra = table.Column<double>(type: "REAL", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SFS = table.Column<double>(type: "REAL", nullable: false),
                    AFP = table.Column<double>(type: "REAL", nullable: false),
                    ISR = table.Column<double>(type: "REAL", nullable: false),
                    SueldoTotal = table.Column<double>(type: "REAL", nullable: false),
                    TotalDecuentos = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nominas", x => x.NominaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Nominas");
        }
    }
}
