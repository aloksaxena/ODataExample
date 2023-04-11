using Coles.PoC.Infra.EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coles.PoC.Infra.EFCore;
	public class RepositoryContext : DbContext
	{
	
		public RepositoryContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<MonthlyDataMasters> MonthlyDataMaster { get; set; }
	}