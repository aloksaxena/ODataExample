using Coles.Poc.MasterDataServices.Model;
using Coles.Poc.MasterDataServices.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coles.Poc.MasterDataServices.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductVariantController : ControllerBase
	{
		private readonly ILogger<ProductVariantController> _logger;

		public ProductVariantController(ILogger<ProductVariantController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetProductVariant")]
		public IEnumerable<ProductVariantResponseModel> Get()
		{
			ProductVariantQuery productVariantQuery = new ProductVariantQuery();
			var res = productVariantQuery.Execute();
			return res.Result.ToArray();
		}
	}
}
