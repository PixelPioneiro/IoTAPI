using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Ativo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Permission = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ativo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatSub",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaId = table.Column<string>(type: "text", nullable: false),
                    SubCategoriaId = table.Column<string>(type: "text", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CategoriaId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    SubCategoriaId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatSub", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatSub_Categoria_CategoriaId1",
                        column: x => x.CategoriaId1,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatSub_SubCategoria_SubCategoriaId1",
                        column: x => x.SubCategoriaId1,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantidadeIn = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    DataIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuantidadeOut = table.Column<decimal>(type: "numeric(7,2)", nullable: false),
                    DataOut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estoque_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    CatSubId = table.Column<Guid>(type: "uuid", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    EstoqueId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_CatSub_CatSubId",
                        column: x => x.CatSubId,
                        principalTable: "CatSub",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatSub_CategoriaId1",
                table: "CatSub",
                column: "CategoriaId1");

            migrationBuilder.CreateIndex(
                name: "IX_CatSub_SubCategoriaId1",
                table: "CatSub",
                column: "SubCategoriaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_ProdutoId1",
                table: "Estoque",
                column: "ProdutoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_UserId",
                table: "Estoque",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CatSubId",
                table: "Produto",
                column: "CatSubId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoria_CategoriaId",
                table: "SubCategoria",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_ProdutoId1",
                table: "Estoque",
                column: "ProdutoId1",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatSub_Categoria_CategoriaId1",
                table: "CatSub");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoria_Categoria_CategoriaId",
                table: "SubCategoria");

            migrationBuilder.DropForeignKey(
                name: "FK_CatSub_SubCategoria_SubCategoriaId1",
                table: "CatSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_ProdutoId1",
                table: "Estoque");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "SubCategoria");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "CatSub");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
