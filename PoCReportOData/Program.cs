using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PoCReportOData;
/*
 https://learn.microsoft.com/en-us/odata/webapi-8/fundamentals/singleton-routing?tabs=visual-studio%2Cnet60
 */
public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		ConfigurationManager configuration = builder.Configuration;
		builder.Services.AddControllers()
			//.AddOData(options => options
			.AddOData(options => options.EnableQueryFeatures(maxTopValue: null)
			.AddRouteComponents("odata", GetEdmModel())
			.Select()
			.Filter()
			.OrderBy()
			.SetMaxTop(20)
			.Count()
			.Expand()
			);


		//builder.Services.AddControllers()
		//	.AddOData(options => options.EnableQueryFeatures(maxTopValue: null)
		//	.AddRouteComponents(
		//	routePrefix: "odata",
		//		model: GetEdmModel()));


		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();
		builder.Services.AddDbContext<ReadingContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
		builder.Services.AddScoped<IReadingRepository, ReadingRepository>();
		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
	static IEdmModel GetEdmModel()
	{
		ODataConventionModelBuilder builder = new();
		builder.EntitySet<Customer>("Customers");
		return builder.GetEdmModel();
	}
}

