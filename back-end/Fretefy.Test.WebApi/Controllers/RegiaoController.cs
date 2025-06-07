using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Entities.DTO;
using Fretefy.Test.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Fretefy.Test.WebApi.Controllers
{
    [Route("api/regiao")]
    [ApiController]
    public class RegiaoController : ControllerBase
    {
        private readonly IRegiaoService _regiaoService;

        public RegiaoController(IRegiaoService regiaoService)
        {
            _regiaoService = regiaoService;
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<RegiaoCidadeDTO> regioes = _regiaoService.List();

            return Ok(regioes);
        }

        [HttpGet("{id}")]
        public IActionResult ListById(Guid id)
        {
            RegiaoCidadeDTO regiao = _regiaoService.ListById(id);

            return Ok(regiao);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Regiao regiao)
        {
            var createdRegiao = _regiaoService.Create(regiao);
            return Ok(createdRegiao);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] RegiaoCidadeDTO regiao)
        {
            var updatedRegiao = _regiaoService.Update(regiao);
            if (updatedRegiao == null)
                return NotFound();

            return Ok(updatedRegiao);
        }

        [HttpPut("SetActive/{id}")]
        public IActionResult SetActive(Guid id)
        {
            _regiaoService.SetActive(id);

            return Ok(true);
        }

        [HttpPut("TurnOff/{id}")]
        public IActionResult TurnOff(Guid id)
        {
            _regiaoService.TurnOff(id);

            return Ok(true);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _regiaoService.Delete(id);
            return NoContent();
        }

        [HttpGet("Export")]
        public async Task<IActionResult> Export()
        {
            var regioes = _regiaoService.Export();

            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                await streamWriter.WriteLineAsync($"Regiao, Status, UF, Cidade");
                foreach (var p in regioes)
                {
                    await streamWriter.WriteLineAsync($"{p.Regiao}, {p.Ativo}, {p.UF}, {p.Cidade}");
                    await streamWriter.FlushAsync();
                }
                await streamWriter.FlushAsync();
            }

            return Ok(File(memoryStream.ToArray(), "text/csv", $"RegioesCidades.csv"));
        }
    }
}
