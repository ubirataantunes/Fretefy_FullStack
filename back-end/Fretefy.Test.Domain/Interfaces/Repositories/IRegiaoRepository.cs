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
        Regiao Add(Regiao regiao);
        Regiao Update(RegiaoCidadeDTO regiao);
        void SetActive(Guid id);
        void TurnOff(Guid id);
        void Delete(Guid id);
        IEnumerable<ExportDTO> Export();
    }
}
