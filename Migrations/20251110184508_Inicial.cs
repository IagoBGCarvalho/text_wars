using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace text_wars.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeClasse = table.Column<string>(type: "varchar(30)", nullable: false),
                    VidaBase = table.Column<int>(type: "INTEGER", nullable: false),
                    ForcaBase = table.Column<double>(type: "REAL", nullable: false),
                    AgilidadeBase = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "varchar(20)", nullable: false),
                    Senha = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "varchar(20)", nullable: false),
                    VidaAtual = table.Column<int>(type: "INTEGER", nullable: false),
                    VidaMaxima = table.Column<int>(type: "INTEGER", nullable: false),
                    Forca = table.Column<double>(type: "REAL", nullable: false),
                    Agilidade = table.Column<double>(type: "REAL", nullable: false),
                    JogadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClasseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personagem_Classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personagem_Jogador_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classe",
                columns: new[] { "Id", "AgilidadeBase", "ForcaBase", "NomeClasse", "VidaBase" },
                values: new object[,]
                {
                    { 1, 30.0, 35.0, "Guerreiro", 100 },
                    { 2, 50.0, 20.0, "Mago", 80 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classe_NomeClasse",
                table: "Classe",
                column: "NomeClasse",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jogador_Login",
                table: "Jogador",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_ClasseId",
                table: "Personagem",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_Personagem_JogadorId",
                table: "Personagem",
                column: "JogadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personagem");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Jogador");
        }
    }
}
