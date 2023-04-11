using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Reflection.Emit;
using PoCReportOData;

namespace PoCReportOData;

public class ReadingContext: DbContext
{
	public ReadingContext(DbContextOptions options) : base(options)
	{ }

	public DbSet<Customer> Customers { get; set; }

	public DbSet<PoCReportOData.OutPutCustomer>? OutPutCustomer { get; set; }

}
