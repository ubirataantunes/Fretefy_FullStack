using Fretefy.Test.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fretefy.Test.Domain.Interfaces
{
    public interface ICidadeService
    {
        Cidade Get(Guid id);
        IEnumerable<Cidade> List();
        IEnumerable<Cidade> ListByUf(string uf);
        IEnumerable<Cidade> Query(string terms);
        Cidade Create(Cidade cidade);
        IEnumerable<Cidade> UpdateLatitudeAndLongitude();
        Cidade UpdateLatitudeAndLongitudeById(Guid id);
        Task<Cidade> SearchMapsApi(Cidade cidade);
    }
}
