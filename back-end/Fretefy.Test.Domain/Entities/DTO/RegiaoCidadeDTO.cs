using System;
using System.Collections.Generic;
using System.Text;

namespace Fretefy.Test.Domain.Entities.DTO
{
    public class RegiaoCidadeDTO : IEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public List<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}
