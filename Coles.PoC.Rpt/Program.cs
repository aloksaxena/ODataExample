
using Coles.PoC.Rpt.Configuration.Routing;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Coles.PoC.Rpt
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			//builder.Services.AddControllers();
			builder.Services.AddControllers(options => // Alok
			{
				options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
			});



			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddHttpContextAccessor();// Alok
			builder.Services.AddRouting(options => // Alok
			{
				// Force all routes to be lowercase
				options.LowercaseUrls = true;
				options.LowercaseQueryStrings = true;

				options.ConstraintMap.Add("slugify", typeof(SlugifyParameterTransformer));
			});

			builder.Services.AddResponseCompression(); // Alok

			builder.Services.Configure<GzipCompressionProviderOptions>(options => // Alok
			{
				options.Level = CompressionLevel.Fastest;
			});

			var app = builder.Build();


			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseRouting(); // Alok
			if (app.Environment.IsDevelopment())// Alok
			{
				// CORS
				app.UseCors();
			}
			app.UseAuthorization();
			app.UseResponseCompression();// Alok
			app.MapDefaultControllerRoute(); // Alok
			
			//app.MapControllers();

			app.Run();
		}
	}
}