using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace senai_inLockCodeFirst_webApi.Migrations
{
    /// <inheritdoc />
    public partial class craicaobanco : Migration
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
                    idEstudio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstudioidEstudio = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogo", x => x.idJogo);
                    table.ForeignKey(
                        name: "FK_Jogo_Estudio_EstudioidEstudio",
                        column: x => x.EstudioidEstudio,
                        principalTable: "Estudio",
                        principalColumn: "idEstudio");
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
                    { new Guid("09f050e3-cb7e-4602-bde6-8838fe5a702d"), "Rockstar Studios" },
                    { new Guid("3a99355e-1d0a-4378-87bf-5a62ce7fe523"), "Square Enix" },
                    { new Guid("6dbf2529-4217-4c25-9ec4-86a1ccb07786"), "Blizzard" }
                });

            migrationBuilder.InsertData(
                table: "Jogo",
                columns: new[] { "idJogo", "EstudioidEstudio", "dataLancamento", "descricao", "idEstudio", "nomeJogo", "valor" },
                values: new object[,]
                {
                    { new Guid("0816328e-ac1d-4930-9c4d-9859c3f64788"), null, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jogo eletrônico de ação-aventura western.", new Guid("09f050e3-cb7e-4602-bde6-8838fe5a702d"), "Red Dead Redemption II", 120.00m },
                    { new Guid("c676c175-bc38-43d4-98fa-b1412bef0d87"), null, new DateTime(2012, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.", new Guid("6dbf2529-4217-4c25-9ec4-86a1ccb07786"), "Diablo 3", 99.00m }
                });

            migrationBuilder.InsertData(
                table: "TipoUsuario",
                columns: new[] { "idTipoUsuario", "titulo" },
                values: new object[,]
                {
                    { new Guid("374390bc-01c8-43b9-8468-8bdac918afff"), "Cliente" },
                    { new Guid("b321c25a-3a83-4ab2-8c3e-c4d46408459e"), "Administrador" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "idUsuario", "email", "idTipoUsuario", "senha" },
                values: new object[,]
                {
                    { new Guid("0077b03f-94ee-490f-acea-0f26a90cc73f"), "admin@admin.com", new Guid("b321c25a-3a83-4ab2-8c3e-c4d46408459e"), "admin" },
                    { new Guid("15fc85fe-9644-4d8b-87d9-2cb9eec4ae6e"), "cliente@cliente.com", new Guid("374390bc-01c8-43b9-8468-8bdac918afff"), "cliente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudio_nomeEstudio",
                table: "Estudio",
                column: "nomeEstudio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogo_EstudioidEstudio",
                table: "Jogo",
                column: "EstudioidEstudio");

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
