namespace Coles.PoC.Infra.EFCore.Entities;
public class MonthlyDataMasters
{
	public int Id { get; set; }
	public int DenominationId { get; set; }
	public DateTime? Period { get; set; }
	public decimal CurrencyInCirculation { get; set; }
	public decimal Withdrawal { get; set; }
	public decimal Retirement { get; set; }
	public decimal Stock { get; set; }
	public string? CreatedBy { get; set; }
}