using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fretefy.Test.Infra.Fretefy.Test.Infra.Data.Migrations
{
    public partial class AddRegiaoAndRegiaoCidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("805855e0-86d6-4f79-bc4e-c3c71b3d827a"), new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5"), new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("f8f3adf6-2c5e-4f2e-9b7e-9fa745672d85"), new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("1ccbd6ae-0e58-4f91-bb02-dad31c8201b1"), new Guid("5d7df2c0-1f33-4bb0-8032-2a6d8f6dcbf9") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5"), new Guid("9e9c4b2f-9c74-438d-98b0-0220193925c1") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("af1c7b8e-d3d8-4d58-b8b6-18fdaab71a92"), new Guid("b0c7d3f3-c1ab-4a2d-9338-c88cc51080c7") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("0c97466d-51b3-4097-93f9-41b7fbc5f8a3"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("1c846b6d-d207-48b3-b70d-e7ac2bc9f101"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("5f402477-3a90-421f-8cde-6d982f1c872d"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("8e9db7f0-e40a-4e68-9b9a-e7efc3ad60c4"), new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735") });

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("4e2736f3-017f-4c6b-81b8-9ba4ed1e37cd"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("5d7df2c0-1f33-4bb0-8032-2a6d8f6dcbf9"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("9e9c4b2f-9c74-438d-98b0-0220193925c1"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("b0c7d3f3-c1ab-4a2d-9338-c88cc51080c7"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("f0f7d0d5-4b6f-4b08-93b2-e49a3f214735"));

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Cidade",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Cidade",
                type: "REAL",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), true, "Norte" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), true, "Nordeste" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333"), true, "Centro-Oeste" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444"), true, "Sudeste" });

            migrationBuilder.InsertData(
                table: "Regiao",
                columns: new[] { "Id", "Ativo", "Nome" },
                values: new object[] { new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555"), true, "Sul" });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("8e9db7f0-e40a-4e68-9b9a-e7efc3ad60c4"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("b07bb4e0-6a90-4f2f-86d7-80b198582dc0"), new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("af1c7b8e-d3d8-4d58-b8b6-18fdaab71a92"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("42c606b9-2958-4961-a3a6-92ccfc3b7078"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("3fbe0e9c-4cc9-4643-9ff1-bc57a9bcb762"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("51b78b97-fb88-4661-bd68-df20c02ae283"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("72a2cb2d-fc50-48e4-a6e9-8599082d2b85"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("8db0d3f9-121b-4f63-8d84-27a2a8dfdfdd"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("09db72f5-ef75-4785-bf59-b5103063acdd"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("d72b501a-34f5-47b2-9a5f-b21b3a3daaa5"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("4d545f9e-1ff4-471a-bbfe-7be8e5b522bc"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("f8f3adf6-2c5e-4f2e-9b7e-9fa745672d85"), new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("332ce25e-47f1-44d9-99d5-1ae913b0ac88"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("6a2b041f-f924-468d-8635-63c62358d435"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("b4abf477-e221-4017-9b62-caa52b24dfb4"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("b51a6b2d-4123-4632-b2c5-87f57d7480db"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("0c97466d-51b3-4097-93f9-41b7fbc5f8a3"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("1c846b6d-d207-48b3-b70d-e7ac2bc9f101"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("7c11f1d4-34bc-4260-a109-b1d7ac1bc129"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("805855e0-86d6-4f79-bc4e-c3c71b3d827a"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("340ebc11-fc7c-49b2-9b4c-00b6f89c9990"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("17e01bc5-9f73-4531-9074-eefb7b8d458d"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("83db2c9e-d62a-48ad-b07f-11f89d504951"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("5f402477-3a90-421f-8cde-6d982f1c872d"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("1ccbd6ae-0e58-4f91-bb02-dad31c8201b1"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.InsertData(
                table: "RegiaoCidade",
                columns: new[] { "CidadeId", "RegiaoId" },
                values: new object[] { new Guid("2eecb465-7f31-4592-81f3-8a5b8fa5b254"), new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("0c97466d-51b3-4097-93f9-41b7fbc5f8a3"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("1c846b6d-d207-48b3-b70d-e7ac2bc9f101"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("1ccbd6ae-0e58-4f91-bb02-dad31c8201b1"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("332ce25e-47f1-44d9-99d5-1ae913b0ac88"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("4d545f9e-1ff4-471a-bbfe-7be8e5b522bc"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("6a2b041f-f924-468d-8635-63c62358d435"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("b4abf477-e221-4017-9b62-caa52b24dfb4"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("b51a6b2d-4123-4632-b2c5-87f57d7480db"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("d72b501a-34f5-47b2-9a5f-b21b3a3daaa5"), new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("2eecb465-7f31-4592-81f3-8a5b8fa5b254"), new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("b07bb4e0-6a90-4f2f-86d7-80b198582dc0"), new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("f8f3adf6-2c5e-4f2e-9b7e-9fa745672d85"), new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("09db72f5-ef75-4785-bf59-b5103063acdd"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("51b78b97-fb88-4661-bd68-df20c02ae283"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("72a2cb2d-fc50-48e4-a6e9-8599082d2b85"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("8db0d3f9-121b-4f63-8d84-27a2a8dfdfdd"), new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("3fbe0e9c-4cc9-4643-9ff1-bc57a9bcb762"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("42c606b9-2958-4961-a3a6-92ccfc3b7078"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("af1c7b8e-d3d8-4d58-b8b6-18fdaab71a92"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5"), new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("17e01bc5-9f73-4531-9074-eefb7b8d458d"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("340ebc11-fc7c-49b2-9b4c-00b6f89c9990"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("5f402477-3a90-421f-8cde-6d982f1c872d"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("7c11f1d4-34bc-4260-a109-b1d7ac1bc129"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("805855e0-86d6-4f79-bc4e-c3c71b3d827a"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("83db2c9e-d62a-48ad-b07f-11f89d504951"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.DeleteData(
                table: "RegiaoCidade",
                keyColumns: new[] { "CidadeId", "RegiaoId" },
                keyValues: new object[] { new Guid("8e9db7f0-e40a-4e68-9b9a-e7efc3ad60c4"), new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111") });

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444"));

            migrationBuilder.DeleteData(
                table: "Regiao",
                keyColumn: "Id",
                keyValue: new Guid("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"));

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Cidade");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Cidade");

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
        }
    }
}
