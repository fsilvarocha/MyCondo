using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCondo.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoCondominio = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "varchar(500)", nullable: true),
                    AreaTotal = table.Column<double>(type: "double(18,5)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(150)", nullable: true),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(150)", nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(150)", nullable: true),
                    Numero = table.Column<string>(type: "varchar(15)", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(100)", nullable: true),
                    Tenante = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Date", nullable: false, defaultValue: new DateTime(2024, 11, 26, 15, 19, 30, 275, DateTimeKind.Local).AddTicks(1973)),
                    DataAtualizado = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blocos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    QuantidadeAndar = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CondominiosId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tenante = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Date", nullable: false, defaultValue: new DateTime(2024, 11, 26, 15, 19, 30, 267, DateTimeKind.Local).AddTicks(2728)),
                    DataAtualizado = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocos_Condominios_CondominiosId",
                        column: x => x.CondominiosId,
                        principalTable: "Condominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocos_CondominiosId",
                table: "Blocos",
                column: "CondominiosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocos");

            migrationBuilder.DropTable(
                name: "Condominios");
        }
    }
}
