using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_UsuariosSistema_UsuarioSistemaId",
                table: "Clientes");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioSistemaId",
                table: "Clientes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_UsuariosSistema_UsuarioSistemaId",
                table: "Clientes",
                column: "UsuarioSistemaId",
                principalTable: "UsuariosSistema",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_UsuariosSistema_UsuarioSistemaId",
                table: "Clientes");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioSistemaId",
                table: "Clientes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_UsuariosSistema_UsuarioSistemaId",
                table: "Clientes",
                column: "UsuarioSistemaId",
                principalTable: "UsuariosSistema",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
