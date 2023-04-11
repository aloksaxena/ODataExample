using Coles.PoC.GraphQL.SetOne.Model;

namespace Coles.PoC.GraphQL.SetOne.Interfaces
{
	public interface IMonthlyDataMasterService
	{
		List<MonthlyDataMaster> GetAllMonthlyDataMasters();
	}
}
