using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace PoCReportOData.Controllers;

[ApiController]
//[Route("api/{controller}")]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
	private readonly ILogger<CustomersController> _logger;
	private readonly IReadingRepository _repository;

	public CustomersController(ILogger<CustomersController> logger, IReadingRepository repository)
	{
		_logger = logger;
		_repository = repository;
	}

	/*
	 https://localhost:7029/odata/Customers?$select=ID,Name & $skip=2
	 * */
	//[EnableQuery(PageSize = 3)]
	[EnableQuery]
	[HttpGet(Name = "GetWeatherForecastaOK")]
	public IQueryable<Customer> Get()
	{
		var result =  _repository.GetCustomersAllAsync();

		return result;
	}
	
	//[HttpGet(Name = "GetWeatherForecastaOK")]
	//public async Task<IEnumerable<Customer>> Get()
	//{
	//	var result = await _repository.GetCustomersWithReadingsAsync();

	//	return result;
	//}
}