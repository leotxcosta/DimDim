using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.Repositories
{
	public interface IDespesaRepository
	{
		Despesa Insert(Despesa despesa);
		IEnumerable<Despesa> FindAll();
		Task<bool> ExcluirAsync(int id);
	}
}
