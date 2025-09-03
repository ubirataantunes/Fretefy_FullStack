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

        public Regiao GetWithCities(Guid id)
        {
            return _dbSet.Include(r => r.RegiaoCidades).FirstOrDefault(r => r.Id == id);
        }

        public Regiao GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(r => r.Id == id);
        }

        public Regiao Add(Regiao regiao)
        {
            _dbSet.Add(regiao);
            _dbContext.SaveChanges();
            return regiao;
        }

        public Regiao Update(Regiao regiao)
        {
             _dbSet.Update(regiao); 
            _dbContext.SaveChanges();
            return regiao;
        }

        public void Delete(Regiao regiao)
        {
            _dbSet.Remove(regiao);
            _dbContext.SaveChanges();
        }

        public IEnumerable<RegiaoExportDTO> Export()
        {
            return _dbSet
                    .Include(r => r.RegiaoCidades)
                    .ThenInclude(rc => rc.Cidade)
                    .AsEnumerable()
                    .SelectMany(r => r.RegiaoCidades.Select(rc => new RegiaoExportDTO
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
