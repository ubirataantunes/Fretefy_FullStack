using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Fretefy.Test.WebApi.Controllers
{
    [Route("api/cidade")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public IActionResult List([FromQuery] string uf, [FromQuery] string terms)
        {
            IEnumerable<Cidade> cidades;

            if (!string.IsNullOrEmpty(terms))
                cidades = _cidadeService.Query(terms);
            else if (!string.IsNullOrEmpty(uf))
                cidades = _cidadeService.ListByUf(uf);
            else
                cidades = _cidadeService.List();

            return Ok(cidades);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var cidades = _cidadeService.Get(id);
            return Ok(cidades);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cidade cidade)
        {
            var createdCidade = _cidadeService.Create(cidade);

            return CreatedAtAction(nameof(Get), new { id = createdCidade.Id }, createdCidade);
        }

        [HttpGet("AtualizarLatitudeELongitudePorId/{id}")]
        public IActionResult UpdateLatitudeLongitude([FromQuery] string id)
        {
            var cidades = _cidadeService.UpdateLatitudeAndLongitudeById(Guid.Parse(id));
            return Ok(cidades);
        }

        [HttpGet("AtualizarLatitudeELongitude")]
        public IActionResult UpdateLatitudeLongitude()
        {
            var cidades = _cidadeService.UpdateLatitudeAndLongitude();
            return Ok(cidades);
        }
    }
}
