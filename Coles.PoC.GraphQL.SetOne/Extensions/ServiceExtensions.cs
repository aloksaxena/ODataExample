using Coles.PoC.Infra.Repositories.Contracts;
using Coles.PoC.Infra.Repositories;
using Coles.PoC.Infra.EFCore;
using Microsoft.EntityFrameworkCore;
using Coles.PoC.GraphQL.SetOne.GraphQLServices;
using Coles.PoC.GraphQL.SetOne.Interfaces;
//using Microsoft.Data.SqlClient;

namespace Coles.PoC.GraphQL.SetOne.Extensions;

public static class ServiceExtensions
{

	/// <summary>
	/// ConfigureRepositoryManager
	/// </summary>
	/// <param name="services">IServiceCollection</param>
	public static void ConfigureRepositoryManager(this IServiceCollection services)
	{
		services.AddScoped<IRepositoryManager, RepositoryManager>();
	}

	/// <summary>
	/// ConfigureServiceManager
	/// </summary>
	/// <param name="services">IServiceCollection</param>
	public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IServiceManager, ServiceManager>();

	public static void ConfigureMonthlyDataMaster(this IServiceCollection services) => services.AddScoped<IMonthlyDataMasterService, MonthlyDataMasterService>();

	/// <summary>
	/// SQL Connection
	/// </summary>
	/// <param name="services"></param>
	/// <param name="configuration"></param>
	public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
	{

		services.AddDbContextPool<RepositoryContext>(optionsAction =>
		{
			//SqlAuthenticationProvider.SetProvider(
			//	SqlAuthenticationMethod.ActiveDirectoryDeviceCodeFlow,
			//	new AzureSqlAuthenticationProvider()
			//);

			string connectionString = configuration.GetConnectionString("sqlConnection");
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				// Fallback to obsolete/deprecated connection string setting
				connectionString = configuration.GetConnectionString("sqlConnection");
			}

			optionsAction.UseSqlServer(
				connectionString,
				sqlServerOptionsAction =>
				{
					sqlServerOptionsAction.CommandTimeout(180);
					sqlServerOptionsAction.EnableRetryOnFailure(2);
				}
			);

			//if (_env.IsDevelopment())
			//{
			optionsAction.EnableSensitiveDataLogging();
			optionsAction.EnableDetailedErrors();
			optionsAction.LogTo(Console.WriteLine);
			//}
		});


	}

	#region Cache
	public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();
	#endregion
}
