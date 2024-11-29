using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCondo.API.Migrations
{
    /// <inheritdoc />
    public partial class CrudMorador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Condominios",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 29, 9, 30, 3, 420, DateTimeKind.Local).AddTicks(574),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 688, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Blocos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 29, 9, 30, 3, 417, DateTimeKind.Local).AddTicks(8268),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 686, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Apartamentos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 29, 9, 30, 3, 410, DateTimeKind.Local).AddTicks(3914),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 681, DateTimeKind.Local).AddTicks(1751));

            migrationBuilder.CreateTable(
                name: "Moradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    TipoMorador = table.Column<int>(type: "INTEGER", nullable: false),
                    ApartamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: false),
                    Tenante = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "Date", nullable: false, defaultValue: new DateTime(2024, 11, 29, 9, 30, 3, 421, DateTimeKind.Local).AddTicks(4145)),
                    DataAtualizado = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moradores_Apartamentos_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moradores_ApartamentoId",
                table: "Moradores",
                column: "ApartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moradores");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Condominios",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 688, DateTimeKind.Local).AddTicks(9554),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 29, 9, 30, 3, 420, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Blocos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 686, DateTimeKind.Local).AddTicks(9060),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 29, 9, 30, 3, 417, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCriacao",
                table: "Apartamentos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 27, 14, 38, 4, 681, DateTimeKind.Local).AddTicks(1751),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldDefaultValue: new DateTime(2024, 11, 29, 9, 30, 3, 410, DateTimeKind.Local).AddTicks(3914));
        }
    }
}
