using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPrestamos.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TelefonoPrincipal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TelefonoOpcional = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Ocupacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NotasAdicionales = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    MontoPrincipal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaInteresAnual = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PlazoMeses = table.Column<int>(type: "int", nullable: false),
                    FrecuenciaPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinPrevista = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TasaInteresMoraAnual = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SaldoPendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaUltimoPago = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminosAdicionales = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecibosCobro",
                columns: table => new
                {
                    ReciboCobroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestamoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoActual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroTransaccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecibosCobro", x => x.ReciboCobroId);
                    table.ForeignKey(
                        name: "FK_RecibosCobro_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecibosCobro_Prestamos_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_ClienteId",
                table: "Prestamos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RecibosCobro_ClienteId",
                table: "RecibosCobro",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RecibosCobro_PrestamoId",
                table: "RecibosCobro",
                column: "PrestamoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecibosCobro");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
