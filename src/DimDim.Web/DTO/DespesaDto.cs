using System;

namespace DimDim.Web.DTO
{
	public class DespesaDto
	{
		public int Id { get; set; }
		public DateTimeOffset Data { get; set; }
		public decimal Valor { get; set; }
		public string Descricao { get; set; }
	}
}