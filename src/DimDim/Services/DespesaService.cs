using DimDim.Commands;
using DimDim.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.Services
{
	public class DespesaService : IDespesaService
	{
		private readonly IDespesaRepository repositorio;

		public DespesaService(IDespesaRepository repositorio)
		{
			this.repositorio = repositorio;
		}

		public IEnumerable<Despesa> Buscar()
		{
			return repositorio.FindAll();
		}

		public Task<bool> ExcluirAsync(int id)
		{
			return repositorio.ExcluirAsync(id);
		}

		public Despesa Registrar(RegistroDespesaCommand registro)
		{
			var d = new Despesa
			{
				Data = registro.Data,
				Valor = registro.Valor,
				Descricao = registro.Descricao
			};

			return repositorio.Insert(d);
		}
	}
}
