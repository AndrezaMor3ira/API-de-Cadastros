using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Migrations
{
    /// <inheritdoc />
    public partial class BancoRegistros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntradaSaida",
                table: "Registros");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Registros",
                newName: "Entrada");

            migrationBuilder.AddColumn<DateTime>(
                name: "Saida",
                table: "Registros",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TempoPermanencia",
                table: "Registros",
                type: "time(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saida",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "TempoPermanencia",
                table: "Registros");

            migrationBuilder.RenameColumn(
                name: "Entrada",
                table: "Registros",
                newName: "DataHora");

            migrationBuilder.AddColumn<bool>(
                name: "EntradaSaida",
                table: "Registros",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
