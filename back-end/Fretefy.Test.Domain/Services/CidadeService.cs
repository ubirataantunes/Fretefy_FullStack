using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fretefy.Test.Domain.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository _cidadeRepository;
        private readonly IConfiguration _configuration;
        private readonly string GoogleMapsAPIUrl;
        private readonly string GoogleMapsKey;

        public CidadeService(ICidadeRepository cidadeRepository, IConfiguration configuration)
        {
            _cidadeRepository = cidadeRepository;
            _configuration = configuration;

            GoogleMapsAPIUrl = _configuration["GoogleMapsAPI:Url"];
            GoogleMapsKey = _configuration["GoogleMapsAPI:Key"];
        }

        public Cidade Get(Guid id)
        {
            return _cidadeRepository.List().FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Cidade> List()
        {
            return _cidadeRepository.List();
        }

        public IEnumerable<Cidade> ListByUf(string uf)
        {
            return _cidadeRepository.ListByUf(uf);
        }

        public IEnumerable<Cidade> Query(string terms)
        {
            return _cidadeRepository.Query(terms);
        }

        public Cidade Create(Cidade cidade)
        {
            if (cidade == null)
                throw new ArgumentNullException(nameof(cidade), "Cidade não pode ser nula.");

            cidade.Id = Guid.NewGuid();

            return _cidadeRepository.Add(cidade);
        }

        public IEnumerable<Cidade> UpdateLatitudeAndLongitude()
        {
            var cidades = _cidadeRepository.List();

            List<Cidade> cidadesUpdated = new List<Cidade>();

            foreach (var cidade in cidades)
            {
                if (cidade.Latitude != null && cidade.Longitude != null)
                {
                    cidadesUpdated.Add(cidade);
                    continue;
                }

                cidadesUpdated.Add(SearchMapsApi(cidade).Result);
            }

            return cidadesUpdated;
        }

        public Cidade UpdateLatitudeAndLongitudeById(Guid id)
        {
            var cidade = _cidadeRepository.List().FirstOrDefault(f => f.Id == id);
            if (cidade == null)
                throw new ArgumentException("Cidade não encontrada.", nameof(id));
            return SearchMapsApi(cidade).Result;
        }

        public async Task<Cidade> SearchMapsApi(Cidade cidade)
        {
            var endereco = $"{cidade.Nome}+{cidade.UF}";
            var url = $"{GoogleMapsAPIUrl}?address={Uri.EscapeDataString(endereco)}&key={GoogleMapsKey}";

            using var httpClient = new HttpClient();

            try
            {
                var response = httpClient.GetAsync(url).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return cidade;
                }

                var json = response.Content.ReadAsStringAsync().Result;
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("results", out var results) && results.GetArrayLength() > 0)
                {
                    var location = results[0]
                        .GetProperty("geometry")
                        .GetProperty("location");

                    var latitude = location.GetProperty("lat").GetDouble();
                    var longitude = location.GetProperty("lng").GetDouble();

                    cidade.UpdateLatitudeAndLongitude(latitude, longitude);
                }

                return _cidadeRepository.Update(cidade);
            }
            catch (Exception ex)
            {
                return cidade;
            }
        }
    }
}
