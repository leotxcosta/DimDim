using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.Web.ViewModels
{
	public class ListaDespesasViewModel
	{
		public ListaDespesasViewModel()
		{
			this.Despesas = Array.Empty<Despesa>();
		}

		public IEnumerable<Despesa> Despesas { get; set; }
	}
}
