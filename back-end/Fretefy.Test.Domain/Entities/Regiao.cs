using Fretefy.Test.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fretefy.Test.Domain.Entities
{
    public class Regiao : IEntity
    {
        public Regiao()
        {
            RegiaoCidades = new List<RegiaoCidade>();
        }

        public Regiao(Guid id, string nome, List<RegiaoCidade> regiaoCidades = null)
        {
            Id = id;
            Nome = nome;
            RegiaoCidades = regiaoCidades ?? new List<RegiaoCidade>();
        }

        public void SetActive() => Ativo = true;
        public void TurnOff() => Ativo = false;

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; private set; }
        public ICollection<RegiaoCidade> RegiaoCidades { get; set; }
    }
}
