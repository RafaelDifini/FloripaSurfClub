using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInheritanceStructurev22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_UsuariosSistema_Id",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendentes_UsuariosSistema_Id",
                table: "Atendentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_UsuariosSistema_Id",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_UsuariosSistema_Id",
                table: "Professores");

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSistemaId",
                table: "Professores",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSistemaId",
                table: "Clientes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSistemaId",
                table: "Atendentes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioSistemaId",
                table: "Alunos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Professores_UsuarioSistemaId",
                table: "Professores",
                column: "UsuarioSistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioSistemaId",
                table: "Clientes",
                column: "UsuarioSistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendentes_UsuarioSistemaId",
                table: "Atendentes",
                column: "UsuarioSistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UsuarioSistemaId",
                table: "Alunos",
                column: "UsuarioSistemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_UsuariosSistema_UsuarioSistemaId",
                table: "Alunos",
                column: "UsuarioSistemaId",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendentes_UsuariosSistema_UsuarioSistemaId",
                table: "Atendentes",
                column: "UsuarioSistemaId",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_UsuariosSistema_UsuarioSistemaId",
                table: "Clientes",
                column: "UsuarioSistemaId",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_UsuariosSistema_UsuarioSistemaId",
                table: "Professores",
                column: "UsuarioSistemaId",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_UsuariosSistema_UsuarioSistemaId",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendentes_UsuariosSistema_UsuarioSistemaId",
                table: "Atendentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_UsuariosSistema_UsuarioSistemaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Professores_UsuariosSistema_UsuarioSistemaId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_UsuarioSistemaId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UsuarioSistemaId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Atendentes_UsuarioSistemaId",
                table: "Atendentes");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_UsuarioSistemaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "UsuarioSistemaId",
                table: "Professores");

            migrationBuilder.DropColumn(
                name: "UsuarioSistemaId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "UsuarioSistemaId",
                table: "Atendentes");

            migrationBuilder.DropColumn(
                name: "UsuarioSistemaId",
                table: "Alunos");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_UsuariosSistema_Id",
                table: "Alunos",
                column: "Id",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendentes_UsuariosSistema_Id",
                table: "Atendentes",
                column: "Id",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_UsuariosSistema_Id",
                table: "Clientes",
                column: "Id",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_UsuariosSistema_Id",
                table: "Professores",
                column: "Id",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
