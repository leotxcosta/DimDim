using System;
using System.ComponentModel.DataAnnotations;

namespace DimDim.Web.DTO
{
	public class RegistroDespesaDto
	{
		[Required]
		public DateTimeOffset Data { get; set; }
		[Required]
		public decimal Valor { get; set; }
		[Required]
		[StringLength(maximumLength: 50, MinimumLength = 3)]
		public string Descricao { get; set; }
	}
}