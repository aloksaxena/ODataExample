using Coles.PoC.GraphQL.SetOne.Interfaces;

namespace Coles.PoC.GraphQL.SetOne.GraphQLServices;

public class IServiceManager
{
	/// <summary>
	/// IClaimService
	/// </summary>
	IMonthlyDataMasterService MonthlyDataMasterService { get; }
}
