using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Entities.DTO;
using System;
using System.Collections.Generic;

namespace Fretefy.Test.Domain.Interfaces
{
    public interface IRegiaoService
    {
        IEnumerable<RegiaoCidadeDTO> List();
        public RegiaoCidadeDTO ListById(Guid regiaoId);
        Regiao Create(Regiao regiao);
        Regiao Update(RegiaoUpdateDTO regiao);
        void SetActive(Guid id);
        void TurnOff(Guid id);
        void Delete(Guid id);
        IEnumerable<RegiaoExportDTO> Export();
    }
}
