using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coles.PoC.Infra.Repositories.Contracts
{
	public interface IRepositoryManager
	{
		/// <summary>
		/// SaveAsync
		/// </summary>
		/// <returns>Task<int></returns>
		Task<int> SaveAsync();

		/// <summary>
		/// ExecuteAsync
		/// </summary>
		/// <param name="action">Func<Task></param>
		/// <returns></returns>
		Task ExecuteAsync(Func<Task> action);

		/// <summary>
		/// IMonthlyDataMasterRepository
		/// </summary>
		IMonthlyDataMasterRepository MonthlyDataMasterRepository { get; }
	}
}
