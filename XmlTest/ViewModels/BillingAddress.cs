using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTest.EntityFramework.ViewModels
{
	public class BillingAddressVM
	{
		public string Email { get; set; }
		public string Name { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public int Zip { get; set; }
		public OrderVM Order { get; set; }
	}
}
