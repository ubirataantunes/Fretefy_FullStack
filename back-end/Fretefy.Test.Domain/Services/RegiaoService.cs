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

        public Regiao Create(RegiaoCreate dto)
        {
            var regiao = new Regiao(dto.Nome, dto.Cidades);

            return _regiaoRepository.Add(regiao);
        }

        public Regiao Update(RegiaoUpdateDTO dto)
        {
            var regiao = _regiaoRepository.GetWithCities(dto.Id);
            if (regiao == null)
                throw new KeyNotFoundException("Região não encontrada.");

            regiao.Update(dto.Nome, dto.Cidades, dto.Ativo);

            return _regiaoRepository.Update(regiao);
        }

        public void SetActive(Guid id)
        {
            var regiao = _regiaoRepository.GetById(id);

            regiao.SetActive();

            _regiaoRepository.Update(regiao);
        }
        public void TurnOff(Guid id)
        {
            var regiao = _regiaoRepository.GetById(id);

            regiao.TurnOff();

            _regiaoRepository.Update(regiao);
        }

        public void Delete(Guid id)
        {
            var regiao = _regiaoRepository.GetWithCities(id);

            _regiaoRepository.Delete(regiao);
        }

        public IEnumerable<RegiaoExportDTO> Export()
        {
            return _regiaoRepository.Export();
        }
    }
}
