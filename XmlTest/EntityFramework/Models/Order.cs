using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTest.EntityFramework.Models
{
	public class Order
	{
		public long Oxid { get; set; }
		public DateTime OrderDate { get; set; }
		public ICollection<Payment> Payments { get; set; }
		public ICollection<OrderArticle> Articles { get; set; }
		public BillingAddress BillingAddress { get; set; }
		public Status Status { get; set; }

		public Order()
		{
			Payments = new List<Payment>();
			Articles = new List<OrderArticle>();
		}
	}

	public enum Status
	{
		Processed = 1,
		Unprocessed,
		Cancelled
	}
}
