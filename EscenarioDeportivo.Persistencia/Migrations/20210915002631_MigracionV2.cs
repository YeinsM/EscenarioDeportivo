using Microsoft.EntityFrameworkCore.Migrations;

namespace EscenarioDeportivo.Persistencia.Migrations
{
    public partial class MigracionV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrenadore_Equipo_EquipoId",
                table: "Entrenadore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrenadore",
                table: "Entrenadore");

            migrationBuilder.RenameTable(
                name: "Entrenadore",
                newName: "Entrenador");

            migrationBuilder.RenameIndex(
                name: "IX_Entrenadore_EquipoId",
                table: "Entrenador",
                newName: "IX_Entrenador_EquipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrenador",
                table: "Entrenador",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrenador_Equipo_EquipoId",
                table: "Entrenador",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrenador_Equipo_EquipoId",
                table: "Entrenador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entrenador",
                table: "Entrenador");

            migrationBuilder.RenameTable(
                name: "Entrenador",
                newName: "Entrenadore");

            migrationBuilder.RenameIndex(
                name: "IX_Entrenador_EquipoId",
                table: "Entrenadore",
                newName: "IX_Entrenadore_EquipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entrenadore",
                table: "Entrenadore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrenadore_Equipo_EquipoId",
                table: "Entrenadore",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
