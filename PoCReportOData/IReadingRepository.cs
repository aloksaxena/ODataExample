namespace PoCReportOData
{
	public interface IReadingRepository
	{
		IQueryable<Customer> GetCustomersAllAsync();
		Task<IEnumerable<Customer>> GetCustomersAsync();
		Task<IEnumerable<Customer>> GetCustomersWithReadingsAsync();
	}
}
