using Coles.PoC.Infra.EFCore.Entities;

namespace Coles.PoC.Infra.Repositories.Contracts;

public interface IMonthlyDataMasterRepository
{
	/// <summary>
	/// GetAllMonthlyDataMaster
	/// </summary>
	List<MonthlyDataMasters> GetAllMonthlyDataMaster();
}