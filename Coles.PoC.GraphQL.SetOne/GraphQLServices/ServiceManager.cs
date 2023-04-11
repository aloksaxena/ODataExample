using Coles.PoC.GraphQL.SetOne.Interfaces;
using Coles.PoC.Infra.Repositories;
using Coles.PoC.Infra.Repositories.Contracts;

namespace Coles.PoC.GraphQL.SetOne.GraphQLServices;

public class ServiceManager: IServiceManager
{
	private readonly Lazy<IMonthlyDataMasterService> _monthlyDataMasterService;

    public ServiceManager(IRepositoryManager repositoryManager, IMonthlyDataMasterService monthlyDataMasterService)
    {
		_monthlyDataMasterService = new Lazy<IMonthlyDataMasterService>(() => new MonthlyDataMasterService(repositoryManager));
	}

	/// <summary>
	/// IClaimService
	/// </summary>
	public IMonthlyDataMasterService MonthlyDataMasterService => _monthlyDataMasterService.Value;
}
