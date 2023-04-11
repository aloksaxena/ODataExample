using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PoCReportOData
{
	public class ReadingRepository : IReadingRepository
	{
		private readonly ReadingContext _context;
		private readonly ILogger<ReadingRepository> _logger;

		public ReadingRepository(ReadingContext context, ILogger<ReadingRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IEnumerable<Customer>> GetCustomersAsync()
		{
			var result = await _context.Customers
			  .OrderBy(c => c.Name)
			  .ToListAsync();

			return result;
		}
		
		public IQueryable<Customer> GetCustomersAllAsync()
		{
			var result = _context.Customers
			  .OrderBy(c => c.Name)
			   .AsQueryable();

			return result;
		}

		public async Task<IEnumerable<Customer>> GetCustomersWithReadingsAsync()
		{
			var result = await _context.Customers
			  .OrderBy(c => c.Name)
			  .ToListAsync();

			return result;
		}

	}
}
