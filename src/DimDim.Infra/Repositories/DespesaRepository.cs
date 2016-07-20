using DimDim.Infra.Data;
using DimDim.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DimDim.Infra.Repositories
{
	public class DespesaRepository : IDespesaRepository
	{
		private readonly DimDimDbContext db;

		public DespesaRepository(DimDimDbContext context)
		{
			db = context;
		}

		public async Task ExcluirAsync(int id)
		{
			var d = await db.Despesas.FirstOrDefaultAsync(x => x.Id == id);

			if (d == null) return;

			db.Despesas.Remove(d);
			await db.SaveChangesAsync();
		}

		public IEnumerable<Despesa> FindAll()
		{
			return db.Despesas.ToList();
		}

		public Despesa Insert(Despesa despesa)
		{
			db.Add(despesa);
			db.SaveChanges();

			return despesa;
		}
	}
}
