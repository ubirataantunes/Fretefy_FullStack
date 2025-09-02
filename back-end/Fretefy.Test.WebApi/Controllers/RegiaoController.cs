using Fretefy.Test.Domain.Entities;
using Fretefy.Test.Domain.Entities.DTO;
using Fretefy.Test.Domain.Interfaces;
using Fretefy.Test.Domain.Utils;
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
            try
            {
                IEnumerable<RegiaoCidadeDTO> regioes = _regiaoService.List();

                if (regioes == null)
                    return NotFound();

                return Ok(regioes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar regiões: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult ListById(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("ID inválido.");

            try
            {
                RegiaoCidadeDTO regiao = _regiaoService.ListById(id);

                if(regiao == null)
                    return NotFound();

                return Ok(regiao);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao listar região: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Regiao regiao)
        {
            try
            {
                var createdRegiao = _regiaoService.Create(regiao);
                return Ok(createdRegiao);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao criar região: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] RegiaoUpdateDTO regiao)
        {
            if (id != regiao.Id)
                return BadRequest("ID da URL diferente do ID do corpo da requisição.");

            try
            {
                var updatedRegiao = _regiaoService.Update(regiao);
                if (updatedRegiao == null)
                    return NotFound();

                return Ok(updatedRegiao);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar região: {ex.Message}");
            }
        }

        [HttpPut("SetActive/{id}")]
        public IActionResult SetActive(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("ID inválido.");

            try
            {
                _regiaoService.SetActive(id);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao ativar região: {ex.Message}");
            }
        }

        [HttpPut("TurnOff/{id}")]
        public IActionResult TurnOff(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("ID inválido.");

            try
            {
                _regiaoService.TurnOff(id);

                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar região: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("ID inválido.");

            try
            {
                _regiaoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao deletar região: {ex.Message}");
            }
        }

        [HttpGet("Export")]
        public async Task<IActionResult> Export()
        {
            try
            {
                var regioes = _regiaoService.Export();

                var file = ExcelExporter.ExportarRegioes(regioes);

                return Ok(File(file, "text/csv", $"RegioesCidades.csv"));
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao exportar: {ex.Message}");
            }
        }
    }
}
