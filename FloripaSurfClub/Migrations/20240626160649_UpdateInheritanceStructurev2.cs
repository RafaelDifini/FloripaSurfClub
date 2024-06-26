using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInheritanceStructurev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Clientes_Id",
                table: "Alunos");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Professores",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Atendentes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Alunos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_UsuariosSistema_Id",
                table: "Alunos",
                column: "Id",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_UsuariosSistema_Id",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Atendentes");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Clientes_Id",
                table: "Alunos",
                column: "Id",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
