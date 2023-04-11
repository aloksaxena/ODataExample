﻿using System.ComponentModel.DataAnnotations;
using System.Net;

namespace PoCReportOData
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string PhoneNumber { get; set; }
		public int AddressId { get; set; }
		
	}

	public partial class OutPutCustomer
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string PhoneNumber { get; set; }
		public int AddressId { get; set; }

	}
}
