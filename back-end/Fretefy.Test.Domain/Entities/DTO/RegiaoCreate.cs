using System;
using System.Collections.Generic;

namespace Fretefy.Test.Domain.Entities.DTO
{
    public class RegiaoCreate
    {
        public string Nome { get; set; }
        public List<Guid> Cidades { get; set; }
    }
}
