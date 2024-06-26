using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    /// <inheritdoc />
    public partial class MudancasProfessores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Professores");

            migrationBuilder.AddColumn<bool>(
                name: "EhPacote",
                table: "Aulas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Aulas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Encerrado",
                table: "Alugueis",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EhPacote",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "Encerrado",
                table: "Alugueis");

            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Professores",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
