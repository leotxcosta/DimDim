using Microsoft.EntityFrameworkCore;

namespace DimDim.Infra.Data
{
	public class DimDimDbContext : DbContext
	{
		public DimDimDbContext(DbContextOptions<DimDimDbContext> options):
			base(options)
		{

		}

		public DbSet<Despesa> Despesas { get; set; }
	}
}
