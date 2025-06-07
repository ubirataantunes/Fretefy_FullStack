using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fretefy.Test.Infra.Fretefy.Test.Infra.Data.Migrations
{
    public partial class NomeDescritivoDaSuaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regiao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegiaoCidade",
                columns: table => new
                {
                    RegiaoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CidadeId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegiaoCidade", x => new { x.RegiaoId, x.CidadeId });
                    table.ForeignKey(
                        name: "FK_RegiaoCidade_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegiaoCidade_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735"), true, "Norte" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("5d7df2c0-1f33-4bb0-8032-2a6d8f6dcbf9"), true, "Nordeste" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("9e9c4b2f-9c74-438d-98b0-0220193925c1"), true, "Centro-Oeste" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd"), false, "Sudeste" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("b0c7d3f3-c1ab-4a2d-9338-c88cc51080c7"), false, "Sul" });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("8e9db7f0-e40a-4e68-9b9a-e7efc3ad60c4"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("1c846b6d-d207-48b3-b70d-e7ac2bc9f101"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("5f402477-3a90-421f-8cde-6d982f1c872d"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("0c97466d-51b3-4097-93f9-41b7fbc5f8a3"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("1ccbd6ae-0e58-4f91-bb02-dad31c8201b1"), new Guid("5d7df2c0-1f33-4bb0-8032-2a6d8f6dcbf9") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5"), new Guid("9e9c4b2f-9c74-438d-98b0-0220193925c1") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5"), new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("f8f3adf6-2c5e-4f2e-9b7e-9fa745672d85"), new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("805855e0-86d6-4f79-bc4e-c3c71b3d827a"), new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("af1c7b8e-d3d8-4d58-b8b6-18fdaab71a92"), new Guid("b0c7d3f3-c1ab-4a2d-9338-c88cc51080c7") });

            migrationBuilder.CreateIndex(
                name: "IX_RegiaoCidade_CidadeId",
                table: "RegiaoCidade",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegiaoCidade");

            migrationBuilder.DropTable(
                name: "Regiao");
        }
    }
}
