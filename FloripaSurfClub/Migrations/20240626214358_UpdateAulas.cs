using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace FloripaSurfClub.Migrations
{
    public partial class UpdateAulas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criando a tabela de junção
            migrationBuilder.CreateTable(
                name: "AulaAluno",
                columns: table => new
                {
                    AulaId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulaAluno", x => new { x.AulaId, x.AlunoId });
                    table.ForeignKey(
                        name: "FK_AulaAluno_Aulas_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aulas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AulaAluno_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Criando índices para as chaves estrangeiras para melhorar o desempenho
            migrationBuilder.CreateIndex(
                name: "IX_AulaAluno_AlunoId",
                table: "AulaAluno",
                column: "AlunoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Removendo a tabela de junção
            migrationBuilder.DropTable(
                name: "AulaAluno");
        }
    }
}
