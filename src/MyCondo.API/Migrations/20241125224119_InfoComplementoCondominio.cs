using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCondo.API.Migrations
{
    /// <inheritdoc />
    public partial class InfoComplementoCondominio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Condominios",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 19, 41, 18, 345, DateTimeKind.Local).AddTicks(8676),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 25, 16, 15, 45, 354, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Condominios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<double>(
                name: "AreaTotal",
                table: "Condominios",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Condominios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Condominios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Condominios",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Condominios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Condominios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Condominios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Condominios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoCondominio",
                table: "Condominios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Condominios",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaTotal",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "TipoCondominio",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Condominios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Condominios",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 25, 16, 15, 45, 354, DateTimeKind.Local).AddTicks(8160),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 25, 19, 41, 18, 345, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "Condominios",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
