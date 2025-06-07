using System;
using Fretefy.Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fretefy.Test.Infra.EntityFramework.Mappings
{
    public class RegiaoMap : IEntityTypeConfiguration<Regiao>
    {
        public void Configure(EntityTypeBuilder<Regiao> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Nome).HasMaxLength(512).IsRequired();
            builder.HasMany(r => r.RegiaoCidades).WithOne(rc => rc.Regiao).HasForeignKey(rc => rc.RegiaoId);

            builder.HasData(
                new Regiao(Guid.Parse("9a2f8e35-32d2-4a58-bd98-1d8d9a1a1111"), "Norte"),
                new Regiao(Guid.Parse("3c7c2b0e-1b3f-4e3a-80dd-2d0f7b2a2222"), "Nordeste"),
                new Regiao(Guid.Parse("6d5e1f14-4bcf-4c67-8a8a-3f4e5c3c3333"), "Centro-Oeste"),
                new Regiao(Guid.Parse("7f8c9e62-7f4e-4b33-aaa1-4d6f8d4d4444"), "Sudeste"),
                new Regiao(Guid.Parse("5e1f8a99-9e3a-4aa1-bb2c-5f7e6e5e5555"), "Sul")
            );

        }
    }
}
