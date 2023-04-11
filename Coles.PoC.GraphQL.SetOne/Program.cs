using Coles.PoC.GraphQL.SetOne.Extensions;
using Coles.PoC.GraphQL.SetOne.GraphQLServices;

namespace Coles.PoC.GraphQL.SetOne
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			builder.Services.ConfigureSqlContext(builder.Configuration);
			builder.Services.ConfigureServiceManager();
			builder.Services.ConfigureRepositoryManager();
			builder.Services.ConfigureMonthlyDataMaster();
			builder.Services.AddGraphQLServer().AddQueryType<MonthlyDataMasterService>().AddProjections().AddFiltering().AddSorting();
			var app = builder.Build();
			app.UseRouting();
			//app.UseEndpoints(endpoints => {
			//	endpoints.MapGraphQL();
			//});

			app.MapGet("/", () => "Hello World!");
			app.MapGraphQL("/graphqlpoc");
			app.Run();
		}
	}
}