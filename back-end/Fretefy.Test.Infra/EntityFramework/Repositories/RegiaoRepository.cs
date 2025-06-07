using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Entities.DTO;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Infra.EntityFramework.Repositories
{
    public class RegiaoRepository : IRegiaoRepository
    {
        private DbSet<Regiao> _dbSet;
        private DbContext _dbContext;

        public RegiaoRepository(DbContext dbContext)
        {
            _dbSet = dbContext.Set<Regiao>();
            _dbContext = dbContext;
        }

        public IEnumerable<RegiaoCidadeDTO> List()
        {
            return _dbSet
                .Include(r => r.RegiaoCidades)
                .ThenInclude(rc => rc.Cidade)
                .Select(r => new RegiaoCidadeDTO
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Ativo = r.Ativo,
                    Cidades = r.RegiaoCidades.Select(rc => new Cidade(
                     rc.Cidade.Id,
                     rc.Cidade.Nome,
                     rc.Cidade.UF,
                     rc.Cidade.Latitude,
                     rc.Cidade.Longitude
                    )).ToList()
                })
                .ToList();
        }

        public RegiaoCidadeDTO ListById(Guid regiaoId)
        {
            return _dbSet
                .Where(r => r.Id == regiaoId)
                .Include(r => r.RegiaoCidades)
                .ThenInclude(rc => rc.Cidade)
                .Select(r => new RegiaoCidadeDTO
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Ativo = r.Ativo,
                    Cidades = r.RegiaoCidades.Select(rc => new Cidade(
                        rc.Cidade.Id,
                        rc.Cidade.Nome,
                        rc.Cidade.UF,
                        rc.Cidade.Latitude,
                        rc.Cidade.Longitude
                        )
                    ).ToList()
                })
                .FirstOrDefault();
        }

        public Regiao GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(r => r.Id == id);
        }

        public Regiao Add(Regiao regiao)
        {
            regiao.Id = Guid.NewGuid();
            regiao.SetActive();

            _dbSet.Add(regiao);
            _dbContext.SaveChanges();

            return regiao;
        }

        public Regiao Update(RegiaoCidadeDTO regiaoAtualizada)
        {
            var regiao = _dbSet
                .Include(r => r.RegiaoCidades)
                .FirstOrDefault(r => r.Id == regiaoAtualizada.Id);

            regiao.Nome = regiaoAtualizada.Nome;

            var novasCidadeIds = regiaoAtualizada.Cidades.Select(c => c.Id).ToList();

            var relacionamentosParaRemover = regiao.RegiaoCidades
                .Where(rc => !novasCidadeIds.Contains(rc.CidadeId))
                .ToList();

            foreach (var rc in relacionamentosParaRemover)
            {
                regiao.RegiaoCidades.Remove(rc);
            }

            foreach (var cidadeId in novasCidadeIds)
            {
                if (!regiao.RegiaoCidades.Any(rc => rc.CidadeId == cidadeId))
                {
                    regiao.RegiaoCidades.Add(new RegiaoCidade
                    {
                        RegiaoId = regiao.Id,
                        CidadeId = cidadeId
                    });
                }
            }

            _dbContext.SaveChanges();

            return regiao;
        }

        public void SetActive(Guid id)
        {
            var regiao = _dbSet.Find(id);

            regiao.SetActive();

            _dbSet.Update(regiao);
            _dbContext.SaveChanges();
        }
        public void TurnOff(Guid id)
        {
            var regiao = _dbSet.Find(id);

            regiao.TurnOff();

            _dbSet.Update(regiao);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var regiao = _dbSet
                .Include(r => r.RegiaoCidades)
                .FirstOrDefault(r => r.Id == id);

            _dbSet.Remove(regiao);
            _dbContext.SaveChanges();
        }



        public IEnumerable<ExportDTO> Export()
        {
            return _dbSet
                    .Include(r => r.RegiaoCidades)
                    .ThenInclude(rc => rc.Cidade)
                    .AsEnumerable()
                    .SelectMany(r => r.RegiaoCidades.Select(rc => new ExportDTO
                    {
                        Regiao = r.Nome,
                        Ativo = r.Ativo,
                        UF = rc.Cidade.UF,
                        Cidade = rc.Cidade.Nome
                    }))
                    .ToList();

        }
    }
}
