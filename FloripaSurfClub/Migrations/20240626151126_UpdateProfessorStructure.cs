using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfessorStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Professores");

            migrationBuilder.RenameColumn(
                name: "ValoresAReceber",
                table: "Professores",
                newName: "ValorAReceber");

            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "Alunos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_UsuariosSistema_Id",
                table: "Professores",
                column: "Id",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_UsuariosSistema_Id",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "ValorAReceber",
                table: "Professores",
                newName: "ValoresAReceber");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Professores",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
