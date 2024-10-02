using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTAPI.Migrations
{
    /// <inheritdoc />
    public partial class Correção : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatSub_Categoria_CategoriaId1",
                table: "CatSub");

            migrationBuilder.DropForeignKey(
                name: "FK_CatSub_SubCategoria_SubCategoriaId1",
                table: "CatSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_ProdutoId1",
                table: "Estoque");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Estoque_EstoqueId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_CatSub_CategoriaId1",
                table: "CatSub");

            migrationBuilder.DropIndex(
                name: "IX_CatSub_SubCategoriaId1",
                table: "CatSub");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "CatSub");

            migrationBuilder.DropColumn(
                name: "SubCategoriaId1",
                table: "CatSub");

            migrationBuilder.RenameColumn(
                name: "ProdutoId1",
                table: "Estoque",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_ProdutoId1",
                table: "Estoque",
                newName: "IX_Estoque_ProdutoId");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubCategoriaId",
                table: "CatSub",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "CatSub",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_CatSub_CategoriaId",
                table: "CatSub",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CatSub_SubCategoriaId",
                table: "CatSub",
                column: "SubCategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CatSub_Categoria_CategoriaId",
                table: "CatSub",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatSub_SubCategoria_SubCategoriaId",
                table: "CatSub",
                column: "SubCategoriaId",
                principalTable: "SubCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatSub_Categoria_CategoriaId",
                table: "CatSub");

            migrationBuilder.DropForeignKey(
                name: "FK_CatSub_SubCategoria_SubCategoriaId",
                table: "CatSub");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoque_Produto_ProdutoId",
                table: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_CatSub_CategoriaId",
                table: "CatSub");

            migrationBuilder.DropIndex(
                name: "IX_CatSub_SubCategoriaId",
                table: "CatSub");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Estoque",
                newName: "ProdutoId1");

            migrationBuilder.RenameIndex(
                name: "IX_Estoque_ProdutoId",
                table: "Estoque",
                newName: "IX_Estoque_ProdutoId1");

            migrationBuilder.AddColumn<Guid>(
                name: "EstoqueId",
                table: "Produto",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubCategoriaId",
                table: "CatSub",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaId",
                table: "CatSub",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId1",
                table: "CatSub",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubCategoriaId1",
                table: "CatSub",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Produto_EstoqueId",
                table: "Produto",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_CatSub_CategoriaId1",
                table: "CatSub",
                column: "CategoriaId1");

            migrationBuilder.CreateIndex(
                name: "IX_CatSub_SubCategoriaId1",
                table: "CatSub",
                column: "SubCategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CatSub_Categoria_CategoriaId1",
                table: "CatSub",
                column: "CategoriaId1",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CatSub_SubCategoria_SubCategoriaId1",
                table: "CatSub",
                column: "SubCategoriaId1",
                principalTable: "SubCategoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estoque_Produto_ProdutoId1",
                table: "Estoque",
                column: "ProdutoId1",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Estoque_EstoqueId",
                table: "Produto",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "Id");
        }
    }
}
