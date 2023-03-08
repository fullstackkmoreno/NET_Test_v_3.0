using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    IdPublicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoIdEstado = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.IdPublicacion);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Estados_EstadoIdEstado",
                        column: x => x.EstadoIdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    IdComentario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublicacionIdPublicacion = table.Column<int>(type: "int", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.IdComentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicaciones_PublicacionIdPublicacion",
                        column: x => x.PublicacionIdPublicacion,
                        principalTable: "Publicaciones",
                        principalColumn: "IdPublicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacionIdPublicacion",
                table: "Comentarios",
                column: "PublicacionIdPublicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_EstadoIdEstado",
                table: "Publicaciones",
                column: "EstadoIdEstado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
