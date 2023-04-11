using Coles.PoC.Infra.EFCore;
using Coles.PoC.Infra.Repositories.Contracts;
using Coles.PoC.Infra.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coles.PoC.Infra.Repositories;

public class RepositoryManager : IRepositoryManager//, IDisposable
{
	private RepositoryContext _repositoryContext;
	private Lazy<IMonthlyDataMasterRepository> _monthlyDataMasterRepository;

	/// <summary>
	/// RepositoryManager constructor
	/// </summary>
	/// <param name="repositoryContext">RepositoryContext</param>
	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
		_monthlyDataMasterRepository = new Lazy<IMonthlyDataMasterRepository>(() => new MonthlyDataMasterRepository(repositoryContext));
	}

	//public void Dispose()
	//{
	//	_repositoryContext.Dispose();
	//}


	/// <summary>
	/// IMonthlyDataMasterRepository
	/// </summary>
	public IMonthlyDataMasterRepository MonthlyDataMasterRepository => _monthlyDataMasterRepository.Value;

	/// <summary>
	/// SaveAsync
	/// </summary>
	/// <returns></returns>
	public Task<int> SaveAsync() => _repositoryContext.SaveChangesAsync();

	/// <summary>
	/// ExecuteAsync
	/// </summary>
	/// <param name="action">Func<Task></param>
	/// <returns></returns>
	public async Task ExecuteAsync(Func<Task> action)
	{
		try
		{
			if (_repositoryContext.Database.CurrentTransaction != null)
			{
				await action();
				return;
			}

			var strategy = _repositoryContext.Database.CreateExecutionStrategy();

			await strategy.ExecuteAsync(async () =>
			{
				using (IDbContextTransaction transaction = _repositoryContext.Database.BeginTransaction())
				{
					try
					{
						await action();
						await transaction.CommitAsync();
					}
					catch (Exception)
					{
						await transaction.RollbackAsync();
						throw;
					}
				}
			});
		}
		catch (Exception)
		{
			_repositoryContext.ChangeTracker.Clear();
			throw;
		}
	}
}