using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInheritanceStructurev24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aulas_Alunos_AlunoId",
                table: "Aulas");

            migrationBuilder.DropIndex(
                name: "IX_Aulas_AlunoId",
                table: "Aulas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Aulas");

            migrationBuilder.CreateTable(
                name: "AulaAluno",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false),
                    AulaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulaAluno", x => new { x.AlunoId, x.AulaId });
                    table.ForeignKey(
                        name: "FK_AulaAluno_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AulaAluno_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AulaAluno_AulaId",
                table: "AulaAluno",
                column: "AulaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AulaAluno");

            migrationBuilder.AddColumn<Guid>(
                name: "AlunoId",
                table: "Aulas",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Aulas_AlunoId",
                table: "Aulas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aulas_Alunos_AlunoId",
                table: "Aulas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
