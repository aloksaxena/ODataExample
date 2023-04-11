using Coles.PoC.Infra.EFCore;
using Coles.PoC.Infra.EFCore.Entities;
using Coles.PoC.Infra.Repositories.Contracts;

namespace Coles.PoC.Infra.Repositories.Repository;

public class MonthlyDataMasterRepository : RepositoryBase<MonthlyDataMasters>, IMonthlyDataMasterRepository
{
	/// <summary>
	/// MonthlyDataMasterRepository
	/// </summary>
	/// <param name="repositoryContext">RepositoryContext</param>
	public MonthlyDataMasterRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

	public List<MonthlyDataMasters> GetAllMonthlyDataMaster()
	{
		var data = FindAll(true).AsQueryable();
		return data.ToList();
	}
}
