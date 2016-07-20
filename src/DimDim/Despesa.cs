using System;

namespace DimDim
{
	public class Despesa
    {
        public Despesa()
        {
        }
				public int Id { get; set;}
				public DateTimeOffset Data { get; set; }
				public decimal Valor { get; set; }
				public string Descricao { get; set; }
	}
}
