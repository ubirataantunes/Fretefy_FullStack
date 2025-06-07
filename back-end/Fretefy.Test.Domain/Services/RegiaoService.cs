using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Entities.DTO;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fretefy.Test.Services
{
    public class RegiaoService : IRegiaoService
    {
        private readonly IRegiaoRepository _regiaoRepository;

        public RegiaoService(IRegiaoRepository regiaoRepository)
        {
            _regiaoRepository = regiaoRepository;
        }

        public IEnumerable<RegiaoCidadeDTO> List()
        {
            return _regiaoRepository.List();
        }

        public RegiaoCidadeDTO ListById(Guid regiaoId)
        {
            return _regiaoRepository.ListById(regiaoId);
        }

        public Regiao Create(Regiao regiao)
        {
            return _regiaoRepository.Add(regiao);
        }
        public Regiao Update(RegiaoCidadeDTO regiaoCidadeDto)
        {
            return _regiaoRepository.Update(regiaoCidadeDto);
        }

        public void SetActive(Guid id)
        {
            _regiaoRepository.SetActive(id);
        }
        public void TurnOff(Guid id)
        {
            _regiaoRepository.TurnOff(id);
        }

        public void Delete(Guid id)
        {
            _regiaoRepository.Delete(id);
        }

        public IEnumerable<ExportDTO> Export()
        {
            return _regiaoRepository.Export();
        }
    }
}
