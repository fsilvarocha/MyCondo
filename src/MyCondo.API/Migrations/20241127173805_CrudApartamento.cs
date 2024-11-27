using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCondo.API.Migrations
{
    /// <inheritdoc />
    public partial class CrudApartamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Condominios",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 688, DateTimeKind.Local).AddTicks(9554),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 26, 15, 19, 30, 275, DateTimeKind.Local).AddTicks(1973));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Blocos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 686, DateTimeKind.Local).AddTicks(9060),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 26, 15, 19, 30, 267, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "varchar(20)", nullable: false),
                    Andar = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    TipoApartamento = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    BlocosId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tenante = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Date", nullable: false, defaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 681, DateTimeKind.Local).AddTicks(1751)),
                    DataAtualizado = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Blocos_BlocosId",
                        column: x => x.BlocosId,
                        principalTable: "Blocos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_BlocosId",
                table: "Apartamentos",
                column: "BlocosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Condominios",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 15, 19, 30, 275, DateTimeKind.Local).AddTicks(1973),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 688, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Blocos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 15, 19, 30, 267, DateTimeKind.Local).AddTicks(2728),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 686, DateTimeKind.Local).AddTicks(9060));
        }
    }
}
