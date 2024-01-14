using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace N5challenge.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permissionType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permissi__3213E83FC618652D", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreempleado = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    apellidoempleado = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    tipopermiso = table.Column<int>(type: "int", nullable: false),
                    fechapermiso = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permissi__3213E83F70DC14C5", x => x.id);
                    table.ForeignKey(
                        name: "FK__permissio__tipop__4BAC3F29",
                        column: x => x.tipopermiso,
                        principalTable: "permissionType",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_permission_tipopermiso",
                table: "permission",
                column: "tipopermiso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "permissionType");
        }
    }
}
