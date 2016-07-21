using DimDim.Commands;
using DimDim.Services;
using DimDim.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.Web.Controllers
{
	[Route("api/[controller]")]
	public class DespesasApiController : Controller
	{
		private readonly IDespesaService despesaService;

		public DespesasApiController(IDespesaService despesaService)
		{
			this.despesaService = despesaService;
		}

		#region WebAPI
		private DespesaDto MapToDto(Despesa d)
		{
			var retorno = new DespesaDto()
			{
				Id = d.Id,
				Data = d.Data,
				Descricao = d.Descricao,
				Valor = d.Valor
			};

			return retorno;
		}


		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete(int id)
		{
			var excluiu = await despesaService.ExcluirAsync(id);

			if (excluiu)
			{
				return Ok();
			}

			return NotFound();
		}

		[HttpGet]
		public IActionResult Get()
		{
			var despesas = despesaService.Buscar();

			var retorno = despesas.ToList().Select(MapToDto);

			return Ok(retorno);
		}

		[HttpPost]
		public IActionResult Post([FromBody] RegistroDespesaDto vm)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var cmd = new RegistroDespesaCommand()
			{
				Data = vm.Data,
				Descricao = vm.Descricao,
				Valor = vm.Valor
			};

			var d = despesaService.Registrar(cmd);

			var retorno = MapToDto(d);

			return Ok(retorno);
		}
		#endregion WebAPI
	}
}
