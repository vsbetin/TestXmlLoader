using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTest.EntityFramework.Models
{
	public class BillingAddress
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public int Zip { get; set; }
		public Order Order { get; set; }
		public long OrderId { get; set; }
	}
}
