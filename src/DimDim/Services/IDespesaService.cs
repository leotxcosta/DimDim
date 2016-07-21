using DimDim.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.Services
{
	public interface IDespesaService
	{
		Despesa Registrar(RegistroDespesaCommand registro);
		IEnumerable<Despesa> Buscar();
		Task<bool> ExcluirAsync(int id);
	}
}
