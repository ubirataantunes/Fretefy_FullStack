using System;
using Fretefy.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fretefy.Test.Infra.EntityFramework.Mappings
{
    public class RegiaoCidadeMap : IEntityTypeConfiguration<RegiaoCidade>
    {
        public void Configure(EntityTypeBuilder<RegiaoCidade> builder)
        {
            builder.HasKey(rc => new { rc.RegiaoId, rc.CidadeId });

            builder.HasOne(rc => rc.Regiao)
                   .WithMany(r => r.RegiaoCidades)
                   .HasForeignKey(rc => rc.RegiaoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rc => rc.Cidade)
                   .WithMany()
                   .HasForeignKey(rc => rc.CidadeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
// Norte (9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111)
                new RegiaoCidade(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), Guid.Parse("8e9db7f0-e40a-4e68-9b9a-e7efc3ad60c4")), // Rio Branco - AC
                new RegiaoCidade(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), Guid.Parse("5f402477-3a90-421f-8cde-6d982f1c872d")), // Macapá - AP
                new RegiaoCidade(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), Guid.Parse("83db2c9e-d62a-48ad-b07f-11f89d504951")), // Manaus - AM
                new RegiaoCidade(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), Guid.Parse("17e01bc5-9f73-4531-9074-eefb7b8d458d")), // Belém - PA
                new RegiaoCidade(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), Guid.Parse("340ebc11-fc7c-49b2-9b4c-00b6f89c9990")), // Porto Velho - RO
                new RegiaoCidade(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), Guid.Parse("805855e0-86d6-4f79-bc4e-c3c71b3d827a")), // Boa Vista - RR
                new RegiaoCidade(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), Guid.Parse("7c11f1d4-34bc-4260-a109-b1d7ac1bc129")), // Palmas - TO

                // Nordeste (3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222)
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("1c846b6d-d207-48b3-b70d-e7ac2bc9f101")), // Maceió - AL
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("0c97466d-51b3-4097-93f9-41b7fbc5f8a3")), // Salvador - BA
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("b51a6b2d-4123-4632-b2c5-87f57d7480db")), // Fortaleza - CE
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("b4abf477-e221-4017-9b62-caa52b24dfb4")), // São Luís - MA
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("6a2b041f-f924-468d-8635-63c62358d435")), // João Pessoa - PB
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("1ccbd6ae-0e58-4f91-bb02-dad31c8201b1")), // Recife - PE
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("332ce25e-47f1-44d9-99d5-1ae913b0ac88")), // Teresina - PI
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("4d545f9e-1ff4-471a-bbfe-7be8e5b522bc")), // Natal - RN
                new RegiaoCidade(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), Guid.Parse("d72b501a-34f5-47b2-9a5f-b21b3a3daaa5")), // Aracaju - SE

                // Centro-Oeste (6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333)
                new RegiaoCidade(Guid.Parse("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333"), Guid.Parse("09db72f5-ef75-4785-bf59-b5103063acdd")), // Brasília - DF
                new RegiaoCidade(Guid.Parse("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333"), Guid.Parse("8db0d3f9-121b-4f63-8d84-27a2a8dfdfdd")), // Goiânia - GO
                new RegiaoCidade(Guid.Parse("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333"), Guid.Parse("72a2cb2d-fc50-48e4-a6e9-8599082d2b85")), // Cuiabá - MT
                new RegiaoCidade(Guid.Parse("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333"), Guid.Parse("51b78b97-fb88-4661-bd68-df20c02ae283")), // Campo Grande - MS

                // Sudeste (7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444)
                new RegiaoCidade(Guid.Parse("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444"), Guid.Parse("3fbe0e9c-4cc9-4643-9ff1-bc57a9bcb762")), // Belo Horizonte - MG
                new RegiaoCidade(Guid.Parse("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444"), Guid.Parse("42c606b9-2958-4961-a3a6-92ccfc3b7078")), // Vitória - ES
                new RegiaoCidade(Guid.Parse("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444"), Guid.Parse("dd99bc63-4772-4ec0-a9b2-4c345f4d7de5")), // Rio de Janeiro - RJ
                new RegiaoCidade(Guid.Parse("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444"), Guid.Parse("af1c7b8e-d3d8-4d58-b8b6-18fdaab71a92")), // São Paulo - SP

                // Sul (5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555)
                new RegiaoCidade(Guid.Parse("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555"), Guid.Parse("b07bb4e0-6a90-4f2f-86d7-80b198582dc0")), // Curitiba - PR
                new RegiaoCidade(Guid.Parse("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555"), Guid.Parse("f8f3adf6-2c5e-4f2e-9b7e-9fa745672d85")), // Porto Alegre - RS
                new RegiaoCidade(Guid.Parse("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555"), Guid.Parse("2eecb465-7f31-4592-81f3-8a5b8fa5b254"))  // Florianópolis - SC
           );
        }
    }
}