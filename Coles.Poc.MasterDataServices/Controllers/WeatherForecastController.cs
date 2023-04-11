using Coles.Poc.MasterDataServices.Model;
using Coles.Poc.MasterDataServices.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Xml.Linq;

namespace Coles.Poc.MasterDataServices.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	private readonly ILogger<WeatherForecastController> _logger;

	public WeatherForecastController(ILogger<WeatherForecastController> logger)
	{
		_logger = logger;
	}

	//[HttpGet(Name = "GetWeatherForecast")]
	//public IEnumerable<ProductVariantResponseModel> Get()
	//{
	//	ProductVariantQuery productVariantQuery = new ProductVariantQuery();
	//	var res = productVariantQuery.Execute();
	//	return res.Result.ToArray();
	//}

	[HttpGet(Name = "GetProductVariantResponseModel")]
	public IEnumerable<ProductVariantResponseModel> GetProductVariantResponseModel()
	{
		List<ProductVariantResponseModel> res = new List<ProductVariantResponseModel>();
		ProductVariantQuery productVariantQuery = new ProductVariantQuery();

		Observable
			.FromAsync(() => productVariantQuery.Execute())
			//	.ValidateProductVariantResponseModelLength(80)
			.Retry(3)
			//.Catch(Observable.Return(new ProductVariantQuery() { Name = "NA" }))
			.Subscribe((models) =>
			{
				res = models;
			});
		return res;
	}
}

static class ProductVariantResponseObservableExtensions
{
	public static IObservable<ProductVariantResponseModel> ValidateProductVariantResponseModelLength(this IObservable<ProductVariantResponseModel> observable, int maxLength)
	{
		return observable
			.Select(model =>
			{
				if (model == null)
				{
					return Observable.Throw<ProductVariantResponseModel>(new Exception("Empty Data"));
				}

				return Observable.Return(model);
			})
			.Switch();
	}
};
