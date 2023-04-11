using Coles.PoC.GraphQL.SetOne.Interfaces;

namespace Coles.PoC.GraphQL.SetOne.Model
{
	public class MonthlyDataMaster
	{
		public int Id { get; set; }
		public int DenominationId { get; set; }
		public string? Period { get; set; }
		public decimal CurrencyInCirculation { get; set; }
		public decimal Withdrawal { get; set; }
		public decimal Retirement { get; set; }
		public decimal Stock { get; set; }
		public string? CreatedBy { get; set; }

		//public List<MonthlyDataMaster> GetAllMonthlyDataMasters()
		//{
		//	throw new NotImplementedException();
		//}
	}
}
