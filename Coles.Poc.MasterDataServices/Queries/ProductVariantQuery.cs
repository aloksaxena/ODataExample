using Coles.Poc.MasterDataServices.Model;

namespace Coles.Poc.MasterDataServices.Queries;

public class ProductVariantQuery
{
	public async Task<List<ProductVariantResponseModel>> Execute()
	{

		List<ProductVariantResponseModel>? response;
		using (HttpClient client = new HttpClient())
		{
			
			var accessToken = "3f27573f-7145-4402-952c-6880bbe25856";
			var url = "https://cldrun-master-data-api-svt-ause1-og6o2d5ifq-ts.a.run.app/api/v1/MasterData/productvariant?$Filter=isActive eq true&$Top=10";
			//var url = "https://cldrun-master-data-api-svt-ause1-og6o2d5ifq-ts.a.run.app/api/v1/MasterData/productvariant?$Filter=isActive eq true";
			//var url = "https://cldrun-master-data-api-svt-ause1-og6o2d5ifq-ts.a.run.app/api/v1/MasterData/productvariant";

			client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
			try
			{
				response = await client.GetFromJsonAsync<List<ProductVariantResponseModel>>(url);
				if (response == null)
				{
					return null;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return response;
		}
	}
}