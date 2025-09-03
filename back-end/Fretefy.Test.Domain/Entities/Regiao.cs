using Fretefy.Test.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Domain.Entities
{
    public class Regiao : IEntity
    {
        private readonly List<RegiaoCidade> _regiaoCidades = new List<RegiaoCidade>();
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<RegiaoCidade> RegiaoCidades => _regiaoCidades.AsReadOnly();

        public void SetActive() => Ativo = true;
        public void TurnOff() => Ativo = false;


        public Regiao()
        {
        }

        public Regiao(string nome, IEnumerable<Guid> cidades)
        {
            Id = Guid.NewGuid();
            ChangeName(nome);
            SetActive();
            SetCities(cidades);
        }

        /// <summary>
        /// Método mantido apenas para demonstração da API
        /// </summary>
        public Regiao(Guid id, string nome)
        {
            Id = Guid.NewGuid();
            ChangeName(nome);
            SetActive();
        }

        public void Update(string nome, IEnumerable<Guid> cidades, bool ativo)
        {
            ChangeName(nome);
            SetCities(cidades);

            if (ativo)
                SetActive();
            else
                TurnOff();
        }

        private void ChangeName(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome da região é obrigatório.");

            Nome = nome;
        }

        private void SetCities(IEnumerable<Guid> cidadeIds)
        {
            if (cidadeIds == null || !cidadeIds.Any())
                throw new ArgumentException("É necessário informar ao menos uma cidade.");

            var distinctCidadeIds = cidadeIds.ToHashSet();

            _regiaoCidades.Clear();

            foreach (var cidadeId in distinctCidadeIds)
            {
                _regiaoCidades.Add(new RegiaoCidade
                {
                    CidadeId = cidadeId,
                    RegiaoId = Id
                });
            }
        }

    }
}
