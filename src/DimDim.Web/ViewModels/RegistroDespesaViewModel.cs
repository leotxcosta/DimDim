using System;

namespace DimDim.Web.ViewModels
{
	public class RegistroDespesaViewModel
	{
		public RegistroDespesaViewModel()
		{
		}

		public DateTimeOffset Data { get; set; }
		public decimal Valor { get; set; }
		public string Descricao { get; set; }
	}
}