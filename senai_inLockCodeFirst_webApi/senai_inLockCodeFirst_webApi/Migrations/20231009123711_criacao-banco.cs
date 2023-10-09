using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace senai_inLockCodeFirst_webApi.Migrations
{
    /// <inheritdoc />
    public partial class criacaobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudio",
                columns: table => new
                {
                    idEstudio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeEstudio = table.Column<string>(type: "VARCHAR(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudio", x => x.idEstudio);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    idTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    titulo = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.idTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Jogo",
                columns: table => new
                {
                    idJogo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomeJogo = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "DATE", nullable: false),
                    valor = table.Column<decimal>(type: "SMALLMONEY", nullable: false),
                    idEstudio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.idJogo);
                    table.ForeignKey(
                        name: "FK_Jogo_Estudio_idEstudio",
                        column: x => x.idEstudio,
                        principalTable: "Estudio",
                        principalColumn: "idEstudio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    senha = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    idTipoUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TipoUsuario_idTipoUsuario",
                        column: x => x.idTipoUsuario,
                        principalTable: "TipoUsuario",
                        principalColumn: "idTipoUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estudio",
                columns: new[] { "idEstudio", "nomeEstudio" },
                values: new object[,]
                {
                    { new Guid("27bbd942-09ef-4cef-8789-2e18c980ab1d"), "Square Enix" },
                    { new Guid("4a2ab164-7751-4da5-ad4f-5c56242d08df"), "Blizzard" },
                    { new Guid("c40b318c-d9c9-436e-bf43-df19ec66a88f"), "Rockstar Studios" }
                });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "titulo" },
                values: new object[,]
                {
                    { new Guid("002437fc-eebb-4cce-8572-43cc0e238a89"), "Cliente" },
                    { new Guid("447efed8-11e8-4cd9-a7de-f16d4e9defb2"), "Administrador" }
                });

            migrationBuilder.InsertData(
                table: "Jogo",
                columns: new[] { "idJogo", "dataLancamento", "descricao", "idEstudio", "nomeJogo", "valor" },
                values: new object[,]
                {
                    { new Guid("1b336681-2030-48e2-81bb-f736dbc60838"), new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.", new Guid("4a2ab164-7751-4da5-ad4f-5c56242d08df"), "Diablo 3", 99.00m },
                    { new Guid("aac29d1f-2380-4933-ad55-d5b509a7c50b"), new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogo eletrônico de ação-aventura western.", new Guid("c40b318c-d9c9-436e-bf43-df19ec66a88f"), "Red Dead Redemption II", 120.00m }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "senha" },
                values: new object[,]
                {
                    { new Guid("a0a0d8b0-c68f-4b83-9e2f-bee87e4084b5"), "cliente@cliente.com", new Guid("002437fc-eebb-4cce-8572-43cc0e238a89"), "cliente" },
                    { new Guid("d2d855f0-4c82-487f-a84e-1bc1b2824561"), "admin@admin.com", new Guid("447efed8-11e8-4cd9-a7de-f16d4e9defb2"), "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudio_nomeEstudio",
                table: "Estudio",
                column: "nomeEstudio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_idEstudio",
                table: "Jogo",
                column: "idEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_nomeJogo",
                table: "Jogo",
                column: "nomeJogo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoUsuario_titulo",
                table: "TipoUsuario",
                column: "titulo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_email",
                table: "Usuario",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_idTipoUsuario",
                table: "Usuario",
                column: "idTipoUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Estudio");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
