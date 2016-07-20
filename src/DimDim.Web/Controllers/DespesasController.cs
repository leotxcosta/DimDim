using Microsoft.AspNetCore.Mvc;
using DimDim.Web.ViewModels;
using DimDim.Services;
using System.Threading.Tasks;
using DimDim.Commands;

namespace DimDim.Web.Controllers
{
	public class DespesasController : Controller
	{
		private readonly IDespesaService despesaService;

		public DespesasController(IDespesaService despesaService)
		{
			this.despesaService = despesaService;
		}
			
		public IActionResult Index()
		{
			var listaDespesas = new ListaDespesasViewModel();
			listaDespesas.Despesas = despesaService.Buscar();

			return View(listaDespesas);
		}

		public IActionResult Registro()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Registro(RegistroDespesaViewModel vm)
		{
			var cmd = new RegistroDespesaCommand()
			{
				Data = vm.Data,
				Descricao = vm.Descricao,
				Valor = vm.Valor
			};

			despesaService.Registrar(cmd);

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Excluir(int id)
		{
			await despesaService.ExcluirAsync(id);

			return RedirectToAction("Index");
		}

	}
}
