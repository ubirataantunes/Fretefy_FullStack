using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Domain.Interfaces.Repositories
{
    public interface IRegiaoRepository
    {
        IEnumerable<RegiaoCidadeDTO> List();
        RegiaoCidadeDTO ListById(Guid regiaoId);
        Regiao GetById(Guid id);
        Regiao GetWithCities(Guid id);
        Regiao Add(Regiao regiao);
        Regiao Update(Regiao regiao);
        void Delete(Regiao id);
        IEnumerable<RegiaoExportDTO> Export();
    }
}
